using MauMau.Abstractions.GameLogic.Factories;
using MauMau.Abstractions.GameLogic.Models;
using MauMau.Abstractions.GameLogic.Models.Cards;
using MauMau.Application.Dto.Game.Creation;
using MauMau.Common.Enums.Cards;
using MauMau.GameLogic.Extensions;
using MauMau.GameLogic.Models.Moves;
using MauMau.Playground.GameLogic.Extensions;
using Microsoft.Extensions.DependencyInjection;

IServiceProvider services = new ServiceCollection()
    .AddGameLogic()
    .BuildServiceProvider();

var playerIds = new[] { Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid() };

var gameCreationDto = new GameCreationDto(playerIds, 1000, Rank.Six, 4);
var gameFactory = services.GetRequiredService<IGameFactory>();
var game = gameFactory.Create(gameCreationDto);

while (true)
{
    Console.WriteLine("Players ids:");
    foreach (Guid playerId in playerIds)
    {
        Console.Write(playerId);
        string isCurrent = playerId == game.CurrentHand.PlayerId
            ? " current"
            : string.Empty;
        Console.WriteLine(isCurrent);
    }

    ICard pileTopCard = game.Pile.Cards.Last();
    Console.WriteLine("\nTop pile card:");
    pileTopCard.PrintInfo();
    Console.WriteLine($"\nLeft in deck: {game.Deck.Cards.Count}");

    Console.WriteLine("\nHand cards:");
    var hand = game.CurrentHand;
    foreach (ICard card in hand.Cards)
        card.PrintInfo();

    IReadOnlyCollection<IMove> availableMoves = hand.GetAvailableMoves(game.Moves);
    Console.WriteLine("\nAvailable moves:");
    foreach ((IMove move, int i) in availableMoves.Select((move, i) => (move, i)))
    {
        Console.Write($"\nMove {i}: ");
        if (move is CardMove cardMove)
        {
            cardMove.Card.PrintInfo();
        }
        else
        {
            Console.WriteLine($"{move.GetType().Name}");
        }
    }

    Console.Write("\nProvide the move number: ");
    int selectedMoveNumber = int.Parse(Console.ReadLine()!.Trim());
    IMove selectedMove = availableMoves.ElementAt(selectedMoveNumber);
    if (selectedMove is PickSuitMove)
    {
        Console.Write("Provide the suit: ");
        var suit = Enum.Parse<Suit>(Console.ReadLine()!.Trim());
        if (suit is Suit.Undefined)
            throw new Exception();

        selectedMove = new PickSuitMove(game.CurrentHand.Id, suit);
    }

    game.PlayMove(selectedMove);
    Console.Clear();
}