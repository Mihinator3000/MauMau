using MauMau.Abstractions.GameLogic.Models.Cards;
using MauMau.Common.Enums.Cards;

namespace MauMau.GameLogic.Models.Cards.Abstractions;

public abstract class BaseCard : ICard
{
    protected BaseCard(Rank rank, Suit suit)
    {
        Rank = rank;
        Suit = suit;
    }

    public Rank Rank { get; }
    public Suit Suit { get; }

    public virtual int Weight => (int)Rank;

    public abstract bool CanBePlayed(ICard previousCard);

    protected bool HasSameRankOrSuit(ICard card)
        => Rank == card.Rank || Suit == card.Suit;
}