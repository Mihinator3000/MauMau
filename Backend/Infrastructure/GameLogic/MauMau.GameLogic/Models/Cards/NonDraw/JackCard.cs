using MauMau.Common.Enums.Cards;
using MauMau.GameLogic.Cards.Abstractions;

namespace MauMau.GameLogic.Models.Cards.NonDraw;

public class JackCard : NonDrawCard
{
    public JackCard(Suit suit) : base(Rank.Jack, suit) { }

    public override int Weight => 2;
}