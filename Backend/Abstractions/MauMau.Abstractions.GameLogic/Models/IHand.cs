using MauMau.Abstractions.GameLogic.Cards;

namespace MauMau.Abstractions.GameLogic.Models;

public interface IHand
{
    Guid Id { get; }
    Guid PlayerId { get; }

    IReadOnlyCollection<ICard> Cards { get; }

    void AddCard(ICard card);

    void PlayCardToPile(ICard card, IPile pile);

    IReadOnlyCollection<IMove> GetAvailableMoves(IReadOnlyList<IMove> previousMoves);
}