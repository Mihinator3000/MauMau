using MauMau.Common.Enums.Cards;

namespace MauMau.GameLogic.Models.Cards.Abstractions;

public abstract class DrawCard : BaseCard
{
    protected DrawCard(Rank rank, Suit suit) : base(rank, suit) { }

    public abstract int DrawAmount { get; }
}