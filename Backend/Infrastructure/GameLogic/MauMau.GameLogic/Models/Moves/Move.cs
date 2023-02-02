using MauMau.Abstractions.GameLogic.Models;
using MauMau.GameLogic.Cards.NonDraw;

namespace MauMau.GameLogic.Models.Moves;

public abstract record Move(Guid HandId) : IMove
{
    public abstract bool CanBePlayed(IReadOnlyList<IMove> moves);

    public abstract void Play(IGame game);

    protected bool EightInThreeMovesWithOnlyDraws(IReadOnlyList<IMove> moves)
    {
        for (int i = 1; i <= moves.Count && i <= 3; i++)
        {
            var move = moves[^i];
            if (move.HandId != HandId)
                return false;

            switch (move)
            {
                case DrawMove:
                    continue;
                case CardMove cardMove:
                    return cardMove.Card is EightCard;
                default:
                    return false;
            }
        }

        return false;
    }

    protected static bool IsLastCardQueen(IReadOnlyList<IMove> moves)
        => moves[^1] is CardMove { Card: QueenCard };
}