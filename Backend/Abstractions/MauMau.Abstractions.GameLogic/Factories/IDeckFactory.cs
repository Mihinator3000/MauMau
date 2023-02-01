using MauMau.Abstractions.GameLogic.Models;
using MauMau.Common.Enums.Cards;

namespace MauMau.Abstractions.GameLogic.Factories;

public interface IDeckFactory
{
    IDeck Create(Rank minRank);
}