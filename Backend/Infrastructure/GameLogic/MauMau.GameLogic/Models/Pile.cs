using MauMau.Abstractions.GameLogic.Cards;
using MauMau.Abstractions.GameLogic.Models;
using MauMau.Common.Exceptions;

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
        if (_cards.Count is 0)
            throw new EndGameException();

        deck.AddCards(_cards);
        _cards.Clear();
    }
}