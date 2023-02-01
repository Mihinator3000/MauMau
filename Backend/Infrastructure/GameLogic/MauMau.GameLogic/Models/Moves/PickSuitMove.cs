using MauMau.Abstractions.GameLogic.Models;
using MauMau.Common.Enums.Cards;
using MauMau.GameLogic.Cards.NonDraw;

namespace MauMau.GameLogic.Models.Moves;

public record PickSuitMove(Guid HandId, Suit Suit) : Move(HandId)
{
    public override bool CanBePlayed(IReadOnlyList<IMove> moves)
        => moves[^1] is CardMove { Card: QueenCard };

    public override void Play(IGame game)
        => game.SetNextHandCurrent();
}