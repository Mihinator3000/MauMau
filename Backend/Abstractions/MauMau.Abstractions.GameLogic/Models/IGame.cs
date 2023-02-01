namespace MauMau.Abstractions.GameLogic.Models;

public interface IGame
{
    Guid Id { get; }
    long WinMoney { get; }

    IDeck Deck { get; }
    IPile Pile { get; }

    IReadOnlyCollection<IHand> Hands { get; }

    IReadOnlyList<IMove> Moves { get; }

    int MovesLeftCount { get; }
    int CurrentHandNumber { get; }
    bool IsRotationClockwise { get; }

    IHand CurrentHand { get; }

    void Start();
    void PlayMove(IMove move);
    void SetNextHandCurrent();
    void ChangeRotation();
}