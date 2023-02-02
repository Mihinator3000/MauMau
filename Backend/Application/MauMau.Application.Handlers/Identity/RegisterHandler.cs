using MauMau.Abstractions.Application.Factories;
using MauMau.Abstractions.Application.Services;
using MauMau.Abstractions.DataAccess;
using MauMau.Application.Dto.Identity;
using MauMau.Core.Identity;
using MauMau.Core.Players;
using Mediator;
using Microsoft.EntityFrameworkCore;
using static MauMau.Application.Requests.Identity.Register;

namespace MauMau.Application.Handlers.Identity;

public class RegisterHandler : IRequestHandler<Request, Response>
{
    private const string UserRole = "User";

    private readonly IMauMauDbContext _context;
    private readonly IPasswordEncoder _passwordEncoder;
    private readonly IUserPlayerFactory _userPlayerFactory;
    private readonly IAccessTokenFactory _accessTokenFactory;

    public RegisterHandler(
        IMauMauDbContext context,
        IPasswordEncoder passwordEncoder,
        IUserPlayerFactory userPlayerFactory,
        IAccessTokenFactory accessTokenFactory)
    {
        _context = context;
        _passwordEncoder = passwordEncoder;
        _userPlayerFactory = userPlayerFactory;
        _accessTokenFactory = accessTokenFactory;
    }

    public async ValueTask<Response> Handle(Request request, CancellationToken cancellationToken)
    {
        RegisterDataDto registerData = request.RegisterData;

        string password = _passwordEncoder.Encode(registerData.Password);
        UserPlayer player = _userPlayerFactory.Create();

        Role userRole = await _context.Roles.FirstAsync(r => r.Name == UserRole, cancellationToken);

        var user = new User(registerData.Username, registerData.Email, password, userRole, player);
        await _context.Users.AddAsync(user, cancellationToken);

        AccessToken accessToken = _accessTokenFactory.Create(user);
        await _context.AccessTokens.AddAsync(accessToken, cancellationToken);

        await _context.SaveChangesAsync(cancellationToken);
        return new Response(accessToken.Value);
    }
}