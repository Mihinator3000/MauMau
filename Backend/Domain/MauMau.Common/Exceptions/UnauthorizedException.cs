namespace MauMau.Common.Exceptions;

public class UnauthorizedException : Exception
{
    public UnauthorizedException(string? message) : base(message) { }

    public static UnauthorizedException InvalidLoginData()
        => new("Username/E-mail or password is invalid");

    public static UnauthorizedException AccessTokenExpired()
        => new("Access token expired");
}