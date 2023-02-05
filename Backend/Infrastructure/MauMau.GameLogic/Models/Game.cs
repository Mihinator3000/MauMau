using MauMau.Abstractions.GameLogic.Models;
using MauMau.Abstractions.GameLogic.Models.Cards;
using MauMau.Common.Exceptions;
using MauMau.GameLogic.Models.Moves;

namespace MauMau.GameLogic.Models;

public class Game : IGame
{
    private readonly Random _random;

    private readonly List<IHand> _hands;
    private readonly List<IMove> _moves;

    public Game(long winMoney, List<IHand> hands, IDeck deck, IPile pile, List<IMove> moves, Random random)
        : this(Guid.NewGuid(), winMoney, hands, deck, pile, moves, random) { }

    public Game(
        Guid id,
        long winMoney,
        List<IHand> hands,
        IDeck deck,
        IPile pile,
        List<IMove> moves,
        Random random,
        int movesLeftCount = 150,
        int currentHandNumber = 0,
        bool isRotationClockwise = true)
    {
        Id = id;
        WinMoney = winMoney;
        _hands = hands;
        Deck = deck;
        Pile = pile;
        _moves = moves;
        MovesLeftCount = movesLeftCount;
        CurrentHandNumber = currentHandNumber;
        IsRotationClockwise = isRotationClockwise;
        _random = random;
    }

    public Guid Id { get; }

    public long WinMoney { get; }

    public IReadOnlyCollection<IHand> Hands => _hands;

    public IDeck Deck { get; }
    public IPile Pile { get; }

    public IReadOnlyList<IMove> Moves => _moves;

    public int MovesLeftCount { get; private set; }
    public int CurrentHandNumber { get; private set; }
    public bool IsRotationClockwise { get; private set; }

    public IHand CurrentHand => _hands[CurrentHandNumber];

    public void Start()
    {
        CurrentHandNumber = _random.Next(0, _hands.Count);
        int randomCardNumber = _random.Next(0, CurrentHand.Cards.Count);
        ICard randomCard = CurrentHand.Cards.ElementAt(randomCardNumber);
        IMove cardMove = new CardMove(CurrentHand.Id, randomCard);
        PlayMove(cardMove);
    }

    public void PlayMove(IMove move)
    {
        if (_moves.Count is not 0 && !move.CanBePlayed(_moves))
            throw new GameLogicException("Move is not possible");

        _moves.Add(move);
        move.Play(this);
    }

    public void SetNextHandCurrent()
    {
        MovesLeftCount--;
        if (MovesLeftCount is 0)
            throw new EndGameException();

        CurrentHandNumber = GetNextHandNumber();
    }

    public void ChangeRotation()
    {
        IsRotationClockwise = !IsRotationClockwise;
    }

    private int GetNextHandNumber()
    {
        if (IsRotationClockwise)
            return (CurrentHandNumber + 1) % Hands.Count;

        return (CurrentHandNumber + Hands.Count - 1) % Hands.Count;
    }
}