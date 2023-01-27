using MauMau.Common.Enums.Cards;

namespace MauMau.Core.ValueObjects;

public readonly record struct Card(Rank Rank, Suit Suit);