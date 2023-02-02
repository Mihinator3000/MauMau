using MauMau.Abstractions.Application.Factories;
using MauMau.Abstractions.Application.Providers;
using MauMau.Core.Identity;

namespace MauMau.Application.Factories;

public class AccessTokenFactory : IAccessTokenFactory
{
    private static readonly TimeSpan LifeTime = TimeSpan.FromDays(7);

    private readonly IDateTimeProvider _dateTimeProvider;

    public AccessTokenFactory(IDateTimeProvider dateTimeProvider)
    {
        _dateTimeProvider = dateTimeProvider;
    }

    public AccessToken Create(User user)
    {
        string accessToken = Guid.NewGuid().ToString();
        
        DateTime expirationDateTime = _dateTimeProvider.GetCurrentDateTime() + LifeTime;

        return new AccessToken(user, accessToken, expirationDateTime);
    }
}