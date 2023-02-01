using MauMau.Common.Enums.Cards;
using MauMau.GameLogic.Cards.Abstractions;

namespace MauMau.GameLogic.Cards.NonDraw;

public class RegularCard : NonDrawCard
{
    public RegularCard(Rank rank, Suit suit) : base(rank, suit) { }
}