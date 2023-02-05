using MauMau.Abstractions.GameLogic.Models.Cards;

namespace MauMau.GameLogic.Cards.Actions;

public readonly record struct DrawWithoutResponseAction(int DrawAmount) : ICardAction;