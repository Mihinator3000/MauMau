using MauMau.Abstractions.GameLogic.Cards;

namespace MauMau.GameLogic.Cards.Actions;

public readonly struct ChangeRotationAction : ICardAction
{
    public static ICardAction Value { get; } = new ChangeRotationAction();
}