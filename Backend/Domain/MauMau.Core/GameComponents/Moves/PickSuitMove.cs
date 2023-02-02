using MauMau.Common.Enums.Cards;

namespace MauMau.Core.GameComponents.Moves;
public partial class PickSuitMove : Move
{
    public PickSuitMove(Guid id, Hand hand, Suit suit) : base(id, hand)
    {
        if (suit is Suit.Undefined)
            throw new ArgumentException("Suit can't be undefined", nameof(suit));

        Suit = suit;
    }

    public Suit Suit { get; protected init; }
}