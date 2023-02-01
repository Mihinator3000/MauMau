using MauMau.Abstractions.GameLogic.Cards;
using MauMau.Common.Enums.Cards;
using MauMau.GameLogic.Cards.Abstractions;

namespace MauMau.GameLogic.Cards.Draw;

public class SixCard : DrawCard
{
    public SixCard(Suit suit) : base(Rank.Six, suit) { }

    public override int DrawAmount => 1;

    public override bool CanBePlayed(ICard previousCard)
    {
        return previousCard switch
        {
            SixCard => true,
            SevenCard or KingOfSpadesCard => false,
            _ => HasSameRankOrSuit(previousCard)
        };
    }
}