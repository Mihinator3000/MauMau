using MauMau.Abstractions.GameLogic.Models.Cards;

namespace MauMau.GameLogic.Models.Cards.Actions;

public readonly struct ChangeRotationAction : ICardAction
{
    public static ICardAction Value { get; } = new ChangeRotationAction();
}