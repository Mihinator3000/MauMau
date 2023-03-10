using MauMau.Abstractions.GameLogic.Models.Cards;
using MauMau.Common.Enums.Cards;
using MauMau.GameLogic.Models.Cards.Abstractions;

namespace MauMau.GameLogic.Models.Cards.Draw;

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