using MauMau.Abstractions.GameLogic.Models.Cards;
using MauMau.Common.Enums.Cards;
using MauMau.GameLogic.Cards.Abstractions;
using MauMau.GameLogic.Cards.Actions;

namespace MauMau.GameLogic.Cards.Draw;

public class KingOfSpadesCard : DrawCard, IActionCard
{
    public KingOfSpadesCard() : base(Rank.King, Suit.Spades) { }

    public override int DrawAmount => 4;

    public override int Weight => 40;

    public override bool CanBePlayed(ICard previousCard)
    {
        return previousCard switch
        {
            SixCard or SevenCard => false,
            _ => HasSameRankOrSuit(previousCard)
        };
    }

    public ICardAction GetCardAction()
        => new DrawWithoutResponseAction(DrawAmount);
}