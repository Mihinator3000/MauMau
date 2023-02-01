using MauMau.Abstractions.GameLogic.Cards;

namespace MauMau.GameLogic.Cards.Abstractions;

public interface IActionCard
{
    ICardAction GetCardAction();
}