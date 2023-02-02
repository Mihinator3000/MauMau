using MauMau.Abstractions.Application.Factories;
using MauMau.Abstractions.Application.Providers;
using MauMau.Core.Players;

namespace MauMau.Application.Factories;

public class UserPlayerFactory : IUserPlayerFactory
{
    private const long DefaultMoneyCount = 1500;

    private readonly IDateTimeProvider _dateTimeProvider;

    public UserPlayerFactory(IDateTimeProvider dateTimeProvider)
    {
        _dateTimeProvider = dateTimeProvider;
    }

    public UserPlayer Create()
    {
        DateTime lastReplenishmentTime = _dateTimeProvider.GetCurrentDateTime();
        return new UserPlayer(DefaultMoneyCount, lastReplenishmentTime);
    }
}