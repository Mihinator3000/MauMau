using MauMau.Abstractions.GameLogic.Models;
using MauMau.Abstractions.GameLogic.Models.Cards;
using MauMau.GameLogic.Models.Moves;

namespace MauMau.GameLogic.Models.Cards.Actions;

public readonly record struct DrawWithoutResponseAction(int DrawAmount) : ICardAction
{
    public void Apply(IGame game)
    {
        game.SetNextHandCurrent();
        game.PlayMove(new DrawMove(game.CurrentHand.Id));
    }
}