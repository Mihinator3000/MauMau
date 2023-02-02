using RichEntity.Annotations;

namespace MauMau.Core.GameComponents.Moves;

public abstract partial class Move : IEntity<Guid>, IEntity
{
    protected Move(Guid id, Hand hand) : this(hand.Id, id)
    {
        Hand = hand;
    }

    [KeyProperty]
    public Hand Hand { get; protected init; }
}