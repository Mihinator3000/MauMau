using MauMau.Abstractions.GameLogic.Cards;
using MauMau.Abstractions.GameLogic.Models;
using MauMau.Common.Enums.Cards;
using MauMau.Common.Exceptions;
using MauMau.GameLogic.Cards.NonDraw;
using MauMau.GameLogic.Extensions;
using MauMau.GameLogic.Models.Moves;

namespace MauMau.GameLogic.Models;

public class Hand : IHand
{
    private readonly List<ICard> _cards;

    public Hand(Guid id, Guid playerId) : this(id, playerId, new List<ICard>()) { }

    public Hand(Guid id, Guid playerId, List<ICard> cards)
    {
        Id = id;
        PlayerId = playerId;
        _cards = cards;
    }

    public Guid Id { get; }
    public Guid PlayerId { get; }

    public IReadOnlyCollection<ICard> Cards => _cards;

    public void AddCard(ICard card)
        => _cards.Add(card);

    public void PlayCardToPile(ICard card, IPile pile)
    {
        if (!_cards.Remove(card))
            throw new GameLogicException($"Couldn't remove card from hand {Id}");

        if (_cards.Count is 0 && card is not EightCard)
            throw new EndGameException();

        pile.AddCard(card);
    }

    public IReadOnlyCollection<IMove> GetAvailableMoves(IReadOnlyList<IMove> previousMoves)
    {
        return _cards
            .Select(c => new CardMove(Id, c))
            .Where<IMove>(c => c.CanBePlayed(previousMoves))
            .AppendIf(new DrawMove(Id), m => m.CanBePlayed(previousMoves))
            .AppendIf(new SkipMove(Id), m => m.CanBePlayed(previousMoves))
            .AppendIf(new PickSuitMove(Id, Suit.Undefined), m => m.CanBePlayed(previousMoves))
            .ToList();
    }
}