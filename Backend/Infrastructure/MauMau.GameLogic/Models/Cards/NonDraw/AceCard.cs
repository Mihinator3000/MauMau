using MauMau.Abstractions.GameLogic.Models.Cards;
using MauMau.Common.Enums.Cards;
using MauMau.GameLogic.Models.Cards.Abstractions;
using MauMau.GameLogic.Models.Cards.Actions;

namespace MauMau.GameLogic.Models.Cards.NonDraw;

public class AceCard : NonDrawCard, IActionCard
{
    public AceCard(Suit suit) : base(Rank.Ace, suit) { }

    public override int Weight => 11;

    public ICardAction GetCardAction()
        => SkipAction.Value;
}