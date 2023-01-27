using MauMau.Core.Identity;

namespace MauMau.Core.Players;

public partial class UserPlayer : Player
{
    public UserPlayer(long money, DateTime lastReplenishmentTime)
        : this(Guid.NewGuid())
    {
        if (money < 0)
            throw new ArgumentException("Money amount cannot be less than zero", nameof(money));

        Money = money;
        LastReplenishmentTime = lastReplenishmentTime;
    }

    public Guid UserId { get; protected init; }
    public User User { get; protected init; } = null!;

    public long Money { get; private set; }

    public DateTime LastReplenishmentTime { get; set; }

    public void AddMoney(long amount)
    {
        Money += amount;
    }

    public bool WithdrawMoney(long amount)
    {
        if (amount > Money)
            return false;

        Money -= amount;
        return true;
    }

    public override string ToString()
        => $"Id: {Id}, User: {User}";
}