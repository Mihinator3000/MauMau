using MauMau.Common.Enums.Cards;
using MauMau.GameLogic.Models.Cards.Abstractions;

namespace MauMau.GameLogic.Models.Cards.NonDraw;

public class RegularCard : NonDrawCard
{
    public RegularCard(Rank rank, Suit suit) : base(rank, suit) { }
}