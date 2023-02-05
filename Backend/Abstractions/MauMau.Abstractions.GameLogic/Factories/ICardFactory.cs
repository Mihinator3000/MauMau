using MauMau.Abstractions.GameLogic.Models.Cards;
using MauMau.Common.Enums.Cards;

namespace MauMau.Abstractions.GameLogic.Factories;

public interface ICardFactory
{
    ICard Create(Rank rank, Suit suit);
}