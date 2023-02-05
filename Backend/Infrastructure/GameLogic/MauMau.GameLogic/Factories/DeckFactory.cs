using MauMau.Abstractions.GameLogic.Factories;
using MauMau.Abstractions.GameLogic.Models;
using MauMau.Abstractions.GameLogic.Models.Cards;
using MauMau.Abstractions.GameLogic.Providers;
using MauMau.Common.Enums.Cards;
using MauMau.GameLogic.Models;

namespace MauMau.GameLogic.Factories;

public class DeckFactory : IDeckFactory
{
    private static readonly IList<Rank> Ranks;
    private static readonly IList<Suit> Suits;

    private readonly ICardFactory _cardFactory;
    private readonly IRandomProvider _randomProvider;

    static DeckFactory()
    {
        Ranks = Enum
            .GetValues<Rank>()
            .Where(r => r is not Rank.Undefined)
            .ToList();

        Suits = Enum
            .GetValues<Suit>()
            .Where(s => s is not Suit.Undefined)
            .ToList();
    }

    public DeckFactory(ICardFactory cardFactory, IRandomProvider randomProvider)
    {
        _cardFactory = cardFactory;
        _randomProvider = randomProvider;
    }

    public IDeck Create(Rank minRank)
    {
        List<ICard> cards = Ranks
            .Where(r => r >= minRank)
            .SelectMany(_ => Suits, _cardFactory.Create)
            .ToList();

        return new Deck(cards, _randomProvider.GetRandom());
    }
}