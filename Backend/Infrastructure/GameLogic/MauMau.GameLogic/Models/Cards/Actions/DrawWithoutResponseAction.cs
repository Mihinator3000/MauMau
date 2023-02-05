using MauMau.Abstractions.GameLogic.Models.Cards;

namespace MauMau.GameLogic.Models.Cards.Actions;

public readonly record struct DrawWithoutResponseAction(int DrawAmount) : ICardAction;