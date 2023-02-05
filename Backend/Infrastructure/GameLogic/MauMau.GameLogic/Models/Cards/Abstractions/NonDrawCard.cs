using MauMau.Abstractions.GameLogic.Models.Cards;
using MauMau.Common.Enums.Cards;

namespace MauMau.GameLogic.Models.Cards.Abstractions;

public abstract class NonDrawCard : BaseCard
{
    protected NonDrawCard(Rank rank, Suit suit) : base(rank, suit) { }

    public override bool CanBePlayed(ICard previousCard)
        => previousCard is not DrawCard && HasSameRankOrSuit(previousCard);
}