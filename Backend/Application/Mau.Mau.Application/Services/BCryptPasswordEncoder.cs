using MauMau.Abstractions.Application.Services;

namespace MauMau.Application.Services;

public class BCryptPasswordEncoder : IPasswordEncoder
{
    private const int EncryptionCost = 10;

    public string Encode(string password)
    {
        return BCrypt.Net.BCrypt.HashPassword(password, EncryptionCost);
    }

    public bool Verify(string password, string encryptedPassword)
    {
        return BCrypt.Net.BCrypt.Verify(password, encryptedPassword);
    }
}