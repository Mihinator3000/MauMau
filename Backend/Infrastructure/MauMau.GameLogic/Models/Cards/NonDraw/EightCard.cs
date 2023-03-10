using MauMau.Abstractions.GameLogic.Models.Cards;
using MauMau.Common.Enums.Cards;
using MauMau.GameLogic.Models.Cards.Abstractions;
using MauMau.GameLogic.Models.Cards.Actions;

namespace MauMau.GameLogic.Models.Cards.NonDraw;

public class EightCard : NonDrawCard, IActionCard
{
    public EightCard(Suit suit) : base(Rank.Eight, suit) { }

    public ICardAction GetCardAction()
        => NotChangeHandAction.Value;
}