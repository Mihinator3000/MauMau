using MauMau.Abstractions.GameLogic.Models.Cards;

namespace MauMau.Playground.GameLogic.Extensions;

public static class CardExtensions
{
    public static void PrintInfo(this ICard card)
    {
        Console.WriteLine($"{card.Rank} {card.Suit}");
    }
}