using MauMau.Application.Dto.Identity;
using Mediator;

namespace MauMau.Application.Requests.Identity;

public static class Login
{
    public record Request(LoginDataDto LoginData) : IRequest<Response>;

    public record Response(string AccessToken);
}