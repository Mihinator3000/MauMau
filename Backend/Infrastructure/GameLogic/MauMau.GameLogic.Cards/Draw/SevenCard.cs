using MauMau.Abstractions.GameLogic.Cards;
using MauMau.Common.Enums.Cards;
using MauMau.GameLogic.Cards.Abstractions;

namespace MauMau.GameLogic.Cards.Draw;

public class SevenCard : DrawCard
{
    public SevenCard(Suit suit) : base(Rank.Seven, suit) { }

    public override int DrawAmount => 2;

    public override bool CanBePlayed(ICard previousCard)
    {
        return previousCard switch
        {
            SevenCard => true,
            SixCard or KingOfSpadesCard => false,
            _ => HasSameRankOrSuit(previousCard)
        };
    }
}