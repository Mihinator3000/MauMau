namespace MauMau.Abstractions.GameLogic.Models;

public interface IMove
{
    Guid HandId { get; }

    bool CanBePlayed(IReadOnlyList<IMove> moves);

    void Play(IGame game);
}