using MauMau.Abstractions.GameLogic.Cards;

namespace MauMau.Abstractions.GameLogic.Models;

public interface IDeck
{
    IReadOnlyCollection<ICard> Cards { get; }

    void AddCards(IReadOnlyCollection<ICard> cards);

    void AddRandomCardToHand(IHand hand, IPile pile);

    void AddRandomCardsToHand(IHand hand, IPile pile, int cardsCount);
}