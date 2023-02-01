using MauMau.Abstractions.GameLogic.Models;
using MauMau.GameLogic.Cards.NonDraw;

namespace MauMau.GameLogic.Models.Moves;

public abstract record Move(Guid HandId) : IMove
{
    public abstract bool CanBePlayed(IReadOnlyList<IMove> moves);

    public abstract void Play(IGame game);

    protected static bool EightInThreeMovesWithOnlyDraws(IReadOnlyList<IMove> moves)
    {
        for (int i = 0; i < moves.Count; i++)
        {
            if (i > 3)
                break;

            switch (moves[^i])
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
}