using MauMau.Core.GameComponents.Moves;
using MauMau.Core.ValueObjects;
using RichEntity.Annotations;

namespace MauMau.Core.GameComponents;

public partial class Game : IEntity<Guid>
{
    public Game(
        Guid id,
        long winMoney,
        Cards deck,
        Cards pile,
        IReadOnlyCollection<Hand> hands,
        IReadOnlyCollection<Move> moves,
        int currentHandNumber,
        bool isRotationClockWise,
        int movesLeftCount)
        : this(id)
    {
        WinMoney = winMoney;
        Deck = deck;
        Pile = pile;
        Hands = hands;
        Moves = moves;
        CurrentHandNumber = currentHandNumber;
        IsRotationClockWise = isRotationClockWise;
        MovesLeftCount = movesLeftCount;
    }

    public long WinMoney { get; protected init; }

    public Cards Deck { get; set; }

    public Cards Pile { get; set; }

    public IReadOnlyCollection<Hand> Hands { get; protected init; }

    public IReadOnlyCollection<Move> Moves { get; protected init; }

    public int CurrentHandNumber { get; set; }

    public bool IsRotationClockWise { get; set; }

    public int MovesLeftCount { get; set; }

    public override string ToString()
        => $"Id: {Id}";
}