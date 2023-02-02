using MauMau.Application.Dto.Identity;
using Mediator;

namespace MauMau.Application.Requests.Identity;

public static class Register
{
    public record Request(RegisterDataDto RegisterData) : IRequest<Response>;

    public record Response(string AccessToken);
}