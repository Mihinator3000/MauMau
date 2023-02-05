using MauMau.Abstractions.GameLogic.Models.Cards;
using MauMau.Common.Enums.Cards;
using MauMau.GameLogic.Cards.Abstractions;
using MauMau.GameLogic.Cards.Actions;

namespace MauMau.GameLogic.Cards.NonDraw;

public class EightCard : NonDrawCard, IActionCard
{
    public EightCard(Suit suit) : base(Rank.Eight, suit) { }

    public ICardAction GetCardAction()
        => NotChangeHandAction.Value;
}