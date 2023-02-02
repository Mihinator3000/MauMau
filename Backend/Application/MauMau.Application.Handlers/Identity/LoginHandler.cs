using MauMau.Abstractions.Application.Factories;
using MauMau.Abstractions.Application.Services;
using MauMau.Abstractions.DataAccess;
using MauMau.Application.Dto.Identity;
using MauMau.Common.Exceptions;
using MauMau.Core.Identity;
using Mediator;
using Microsoft.EntityFrameworkCore;
using static MauMau.Application.Requests.Identity.Login;

namespace MauMau.Application.Handlers.Identity;

public class LoginHandler : IRequestHandler<Request, Response>
{
    private readonly IMauMauDbContext _context;
    private readonly IPasswordEncoder _passwordEncoder;
    private readonly IAccessTokenFactory _accessTokenFactory;

    public LoginHandler(IMauMauDbContext context, IPasswordEncoder passwordEncoder, IAccessTokenFactory accessTokenFactory)
    {
        _context = context;
        _passwordEncoder = passwordEncoder;
        _accessTokenFactory = accessTokenFactory;
    }

    public async ValueTask<Response> Handle(Request request, CancellationToken cancellationToken)
    {
        LoginDataDto loginData = request.LoginData;

        User? user = await _context.Users.FirstOrDefaultAsync(u =>
                u.Name == loginData.EmailOrUsername ||
                u.Email == loginData.EmailOrUsername,
            cancellationToken);
        
        if (user is null || !_passwordEncoder.Verify(loginData.Password, user.Password))
            throw UnauthorizedException.InvalidLoginData();

        string accessToken = await AddAccessToken(user, cancellationToken);

        return new Response(accessToken);
    }

    private async ValueTask<string> AddAccessToken(User user, CancellationToken cancellationToken)
    {
        AccessToken accessToken = _accessTokenFactory.Create(user);

        IQueryable<AccessToken> userAccessTokens = _context.AccessTokens.Where(t => t.User.Id == user.Id);
        _context.AccessTokens.RemoveRange(userAccessTokens);

        await _context.AccessTokens.AddAsync(accessToken, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        return accessToken.Value;
    }
}