using MauMau.Core.ValueObjects;

namespace MauMau.Core.GameComponents.Moves;

public partial class CardMove : Move
{
    public CardMove(Guid id, Hand hand, Card card) : base(id, hand)
    {
        Card = card;
    }

    public Card Card { get; protected init; }
}