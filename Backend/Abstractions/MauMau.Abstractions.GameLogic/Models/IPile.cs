using MauMau.Abstractions.GameLogic.Models.Cards;

namespace MauMau.Abstractions.GameLogic.Models;

public interface IPile
{
    IReadOnlyCollection<ICard> Cards { get; }

    ICard GetTopCard();

    void AddCard(ICard card);

    void MoveCardsToDeck(IDeck deck);
}