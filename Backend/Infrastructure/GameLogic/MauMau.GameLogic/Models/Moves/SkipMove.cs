using MauMau.Abstractions.GameLogic.Models;
using MauMau.GameLogic.Cards.NonDraw;

namespace MauMau.GameLogic.Models.Moves;

public record SkipMove(Guid HandId) : Move(HandId)
{
    public override bool CanBePlayed(IReadOnlyList<IMove> moves)
    {
        IMove lastMove = moves[^1];

        return lastMove switch
        {
            CardMove { Card: AceCard } => true,
            DrawMove => lastMove.HandId == HandId && !EightInThreeMovesWithOnlyDraws(moves),
            _ => false
        };
    }

    public override void Play(IGame game)
        => game.SetNextHandCurrent();
}