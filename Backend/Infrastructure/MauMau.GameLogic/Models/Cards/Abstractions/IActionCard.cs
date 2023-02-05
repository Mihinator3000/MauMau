using MauMau.Abstractions.GameLogic.Models.Cards;

namespace MauMau.GameLogic.Models.Cards.Abstractions;

public interface IActionCard
{
    ICardAction GetCardAction();
}