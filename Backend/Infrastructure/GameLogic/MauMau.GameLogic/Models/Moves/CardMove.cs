using MauMau.Abstractions.GameLogic.Cards;
using MauMau.Abstractions.GameLogic.Models;
using MauMau.Common.Exceptions;
using MauMau.GameLogic.Cards.Abstractions;
using MauMau.GameLogic.Cards.Actions;
using MauMau.GameLogic.Cards.NonDraw.Helpers;

namespace MauMau.GameLogic.Models.Moves;

public record CardMove(Guid HandId, ICard Card) : Move(HandId)
{
    public override bool CanBePlayed(IReadOnlyList<IMove> moves)
    {
        for (int i = 0; i < moves.Count; i++)
        {
            switch (moves[^i])
            {
                case CardMove cardMove:
                    return Card.CanBePlayed(cardMove.Card);
                case PickSuitMove pickSuitMove:
                    var helperCard = new HelperCard(pickSuitMove.Suit);
                    return Card.CanBePlayed(helperCard);
            }
        }

        throw new GameLogicException("Game should have card or pick moves");
    }

    public override void Play(IGame game)
    {
        game.CurrentHand.PlayCardToPile(Card, game.Pile);

        if (Card is not IActionCard actionCard)
        {
            game.SetNextHandCurrent();
            return;
        }

        switch (actionCard.GetCardAction())
        {
            case NotChangeHandAction:
                return;
            case SkipAction:
                game.SetNextHandCurrent();
                game.PlayMove(new SkipMove(game.CurrentHand.Id));
                return;
            case ChangeRotationAction:
                game.ChangeRotation();
                game.SetNextHandCurrent();
                return;
            case DrawWithoutResponseAction:
                game.SetNextHandCurrent();
                game.PlayMove(new DrawMove(game.CurrentHand.Id));
                return;
            default:
                throw new GameLogicException("Action is not supported");
        }
    }
}