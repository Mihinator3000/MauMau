using MauMau.Core.Players;
using RichEntity.Annotations;

namespace MauMau.Core.GameComponents.Options;

public partial class PlayerPosition : IEntity<Guid>
{
    public PlayerPosition(Player player, int position) : this(Guid.NewGuid())
    {
        Player = player;
        Position = position;
    }

    public Player Player { get; protected init; }

    public int Position { get; protected init; }

    public override string ToString()
        => $"Id: {Id}, Player: {Player}";
}