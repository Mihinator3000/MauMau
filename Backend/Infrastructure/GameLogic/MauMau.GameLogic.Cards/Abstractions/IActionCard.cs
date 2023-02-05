using MauMau.Abstractions.GameLogic.Models.Cards;

namespace MauMau.GameLogic.Cards.Abstractions;

public interface IActionCard
{
    ICardAction GetCardAction();
}