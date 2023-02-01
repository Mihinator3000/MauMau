using MauMau.Abstractions.GameLogic.Cards;

namespace MauMau.GameLogic.Cards.Actions;

public readonly struct NotChangeHandAction : ICardAction
{
    public static ICardAction Value { get; } = new NotChangeHandAction();
}