using MauMau.Abstractions.GameLogic.Models;
using MauMau.Abstractions.GameLogic.Models.Cards;
using MauMau.GameLogic.Models.Moves;

namespace MauMau.GameLogic.Models.Cards.Actions;

public readonly struct SkipAction : ICardAction
{
    public static ICardAction Value { get; } = new SkipAction();

    public void Apply(IGame game)
    {
        game.SetNextHandCurrent();
        game.PlayMove(new SkipMove(game.CurrentHand.Id));
    }
}