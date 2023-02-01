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
        IMove lastMove = game.Moves[^2];

        if (lastMove is not CardMove { Card: DrawCard })
        {
            game.Deck.AddRandomCardToHand(game.CurrentHand, game.Pile);
            return;
        }

        int drawAmount = 0;

        for (int i = 1; i < game.Moves.Count; i++)
        {
            IMove move = game.Moves[^i];

            if (move is not CardMove { Card: DrawCard drawCard })
                break;

            drawAmount += drawCard.DrawAmount;
        }

        game.Deck.AddRandomCardsToHand(game.CurrentHand, game.Pile, drawAmount);
        game.SetNextHandCurrent();
    }
}