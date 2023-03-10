using MauMau.Abstractions.GameLogic.Models;
using MauMau.Abstractions.GameLogic.Models.Cards;

namespace MauMau.GameLogic.Models.Cards.Actions;

public readonly struct NotChangeHandAction : ICardAction
{
    public static ICardAction Value { get; } = new NotChangeHandAction();

    public void Apply(IGame game) { }
}