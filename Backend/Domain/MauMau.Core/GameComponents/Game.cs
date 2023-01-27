using MauMau.Core.ValueObjects;
using RichEntity.Annotations;

namespace MauMau.Core.GameComponents;

public partial class Game : IEntity<Guid>
{
    public Game(
        long winMoney,
        IReadOnlyCollection<Hand> hands,
        Cards deck,
        Cards pile,
        int currentHandNumber,
        bool isRotationClockWise,
        int movesLeftCount)
        : this(Guid.NewGuid())
    {
        WinMoney = winMoney;
        Hands = hands;
        Deck = deck;
        Pile = pile;
        CurrentHandNumber = currentHandNumber;
        IsRotationClockWise = isRotationClockWise;
        MovesLeftCount = movesLeftCount;
    }

    public long WinMoney { get; protected init; }

    public IReadOnlyCollection<Hand> Hands { get; protected init; }

    public Cards Deck { get; set; }

    public Cards Pile { get; set; }

    public int CurrentHandNumber { get; set; }

    public bool IsRotationClockWise { get; set; }

    public int MovesLeftCount { get; set; }

    public override string ToString()
        => $"Id: {Id}";
}