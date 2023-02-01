using MauMau.Abstractions.GameLogic.Factories;
using MauMau.Abstractions.GameLogic.Models;
using MauMau.Abstractions.GameLogic.Providers;
using MauMau.Application.Dto.Game.Creation;
using MauMau.GameLogic.Models;

namespace MauMau.GameLogic.Factories;

public class GameFactory : IGameFactory
{
    private readonly IDeckFactory _deckFactory;
    private readonly IRandomProvider _randomProvider;

    public GameFactory(IDeckFactory deckFactory, IRandomProvider randomProvider)
    {
        _deckFactory = deckFactory;
        _randomProvider = randomProvider;
    }

    public IGame Create(GameCreationDto gameCreationDto)
    {
        IPile pile = new Pile();
        IDeck deck = _deckFactory.Create(gameCreationDto.MinCardRank);

        List<IHand> hands = gameCreationDto.PlayerIds
            .Select(i =>
            {
                var hand = new Hand(Guid.NewGuid(), i);
                deck.AddRandomCardsToHand(hand, pile, gameCreationDto.HandSize);
                return hand;
            })
            .ToList<IHand>();

        int playersCount = gameCreationDto.PlayerIds.Count;
        long winMoney = gameCreationDto.Stake * playersCount;
        
        var moves = new List<IMove>();
        var random = _randomProvider.GetRandom();

        var game = new Game(winMoney, hands, deck, pile, moves, random);
        game.Start();
        return game;
    }
}