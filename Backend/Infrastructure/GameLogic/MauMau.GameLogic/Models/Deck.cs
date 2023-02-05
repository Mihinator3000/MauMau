using MauMau.Abstractions.GameLogic.Models;
using MauMau.Abstractions.GameLogic.Models.Cards;

namespace MauMau.GameLogic.Models;

public class Deck : IDeck
{
    private readonly Random _random;

    private readonly List<ICard> _cards;

    public Deck(List<ICard> cards, Random random)
    {
        _cards = cards;
        _random = random;
    }

    public IReadOnlyCollection<ICard> Cards => _cards;

    public void AddCards(IReadOnlyCollection<ICard> cards)
        => _cards.AddRange(cards);

    public void AddRandomCardToHand(IHand hand, IPile pile)
    {
        if (_cards.Count is 0)
            pile.MoveCardsToDeck(this);

        int randomCardNumber = _random.Next(0, _cards.Count);
        ICard randomCard = _cards[randomCardNumber];
        _cards.RemoveAt(randomCardNumber);

        hand.AddCard(randomCard);
    }

    public void AddRandomCardsToHand(IHand hand, IPile pile, int cardsCount)
    {
        for (int i = 0; i < cardsCount; i++)
        {
            AddRandomCardToHand(hand, pile);
        }
    }
}