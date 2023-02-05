using MauMau.Abstractions.GameLogic.Cards;
using MauMau.Abstractions.GameLogic.Models;
using MauMau.Common.Exceptions;
using MauMau.GameLogic.Extensions;

namespace MauMau.GameLogic.Models;

public class Pile : IPile
{
    private readonly List<ICard> _cards;

    public Pile() : this(new List<ICard>()) { }

    public Pile(List<ICard> cards)
    {
        _cards = cards;
    }

    public IReadOnlyCollection<ICard> Cards => _cards;

    public ICard GetTopCard()
    {
        return _cards.Last();
    }

    public void AddCard(ICard card)
    {
        _cards.Add(card);
    }

    public void MoveCardsToDeck(IDeck deck)
    {
        if (_cards.Count is 1)
            throw new EndGameException();

        List<ICard> cardsToMove = _cards.RemoveAndGetRange(0, _cards.Count - 1);
        deck.AddCards(cardsToMove);
    }
}