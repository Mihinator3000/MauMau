using MauMau.Common.Enums.Cards;

namespace MauMau.Abstractions.GameLogic.Models.Cards;

public interface ICard
{
    Rank Rank { get; }

    Suit Suit { get; }

    int Weight { get; }

    bool CanBePlayed(ICard previousCard);
}