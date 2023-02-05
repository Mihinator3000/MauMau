using MauMau.Common.Enums.Cards;
using MauMau.GameLogic.Cards.Abstractions;

namespace MauMau.GameLogic.Models.Cards.NonDraw;

public class NineCard : NonDrawCard
{
    public NineCard(Suit suit) : base(Rank.Nine, suit) { }

    public override int Weight => 0;
}