using MauMau.Abstractions.GameLogic.Models;
using MauMau.Common.Enums.Cards;

namespace MauMau.GameLogic.Models.Moves;

public record PickSuitMove(Guid HandId, Suit Suit) : Move(HandId)
{
    public override bool CanBePlayed(IReadOnlyList<IMove> moves)
        => IsLastCardQueen(moves);

    public override void Play(IGame game)
        => game.SetNextHandCurrent();
}