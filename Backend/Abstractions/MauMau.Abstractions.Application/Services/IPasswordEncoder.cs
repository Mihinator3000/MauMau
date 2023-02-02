namespace MauMau.Abstractions.Application.Services;

public interface IPasswordEncoder
{
    string Encode(string password);

    bool Verify(string password, string encryptedPassword);
}