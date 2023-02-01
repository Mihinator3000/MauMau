using MauMau.Abstractions.GameLogic.Models;
using MauMau.GameLogic.Cards.NonDraw;

namespace MauMau.GameLogic.Models.Moves;

public record SkipMove(Guid HandId) : Move(HandId)
{
    public override bool CanBePlayed(IReadOnlyList<IMove> moves)
    {
        return moves[^1] switch
        {
            CardMove {Card: AceCard} => true,
            DrawMove => !EightInThreeMovesWithOnlyDraws(moves),
            _ => false
        };
    }

    public override void Play(IGame game)
        => game.SetNextHandCurrent();
}