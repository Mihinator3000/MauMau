using MauMau.Common.Enums;

namespace MauMau.Core.Players;

public partial class BotPlayer : Player
{
    public BotPlayer(BotDifficulty difficulty) : this(Guid.NewGuid())
    {
        Difficulty = difficulty;
    }

    public BotDifficulty Difficulty { get; protected init; }

    public override string ToString()
        => $"Id: {Id}, Difficulty: {Difficulty}";
}