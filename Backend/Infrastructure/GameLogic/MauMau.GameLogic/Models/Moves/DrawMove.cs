using MauMau.Abstractions.GameLogic.Models;
using MauMau.GameLogic.Cards.Abstractions;

namespace MauMau.GameLogic.Models.Moves;

public record DrawMove(Guid HandId) : Move(HandId)
{
    public override bool CanBePlayed(IReadOnlyList<IMove> moves)
    {
        if (IsLastCardQueen(moves))
            return false;
        
        if (moves[^1].HandId != HandId)
            return true;

        return EightInThreeMovesWithOnlyDraws(moves);
    }

    public override void Play(IGame game)
    {
        IList<IMove> movesBeforeCurrent = game.Moves
            .SkipLast(1)
            .ToList();

        IMove lastMove = movesBeforeCurrent[^1];

        if (lastMove is not CardMove { Card: DrawCard })
        {
            game.Deck.AddRandomCardToHand(game.CurrentHand, game.Pile);
            return;
        }

        int drawAmount = 0;

        for (int i = movesBeforeCurrent.Count - 1; i >= 0; i--)
        {
            IMove move = movesBeforeCurrent[i];

            if (move is not CardMove { Card: DrawCard drawCard })
                break;

            drawAmount += drawCard.DrawAmount;
        }

        game.Deck.AddRandomCardsToHand(game.CurrentHand, game.Pile, drawAmount);
        game.SetNextHandCurrent();
    }
}