using MauMau.Core.Players;
using MauMau.Core.ValueObjects;
using RichEntity.Annotations;

namespace MauMau.Core.GameComponents;

public partial class Hand : IEntity<Guid>
{
    public Hand(Player player, Cards cards) : this(Guid.NewGuid())
    {
        Player = player;
        Cards = cards;
    }

    public Player Player { get; protected init; }

    public Cards Cards { get; protected init; }

    public override string ToString()
        => $"Id: {Id}, Player: {Player}";
}