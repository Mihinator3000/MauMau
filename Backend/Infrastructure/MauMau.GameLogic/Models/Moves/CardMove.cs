using MauMau.Abstractions.GameLogic.Models;
using MauMau.Abstractions.GameLogic.Models.Cards;
using MauMau.Common.Exceptions;
using MauMau.GameLogic.Models.Cards.Abstractions;
using MauMau.GameLogic.Models.Cards.Actions;
using MauMau.GameLogic.Models.Cards.NonDraw.Helpers;

namespace MauMau.GameLogic.Models.Moves;

public record CardMove(Guid HandId, ICard Card) : Move(HandId)
{
    public override bool CanBePlayed(IReadOnlyList<IMove> moves)
    {
        if (IsLastCardQueen(moves))
            return false;

        for (int i = 1; i <= moves.Count; i++)
        {
            switch (moves[^i])
            {
                case CardMove cardMove:
                {
                    var card = cardMove.Card;
                    if (i is 1)
                        return Card.CanBePlayed(card);

                    var helperNonDrawCard = new HelperCard(card.Suit, card.Rank);
                    return Card.CanBePlayed(helperNonDrawCard);
                }
                case PickSuitMove pickSuitMove:
                {
                    var helperSuitCard = new HelperCard(pickSuitMove.Suit);
                    return Card.CanBePlayed(helperSuitCard);
                }
            }
        }

        throw new GameLogicException("Game should have card or pick moves");
    }

    public override void Play(IGame game)
    {
        game.CurrentHand.PlayCardToPile(Card, game.Pile);

        if (Card is IActionCard actionCard)
        {
            var cardAction = actionCard.GetCardAction();
            cardAction.Apply(game);
            return;
        }

        game.SetNextHandCurrent();
    }
}