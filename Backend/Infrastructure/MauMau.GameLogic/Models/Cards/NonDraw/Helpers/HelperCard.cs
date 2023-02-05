using MauMau.Common.Enums.Cards;
using MauMau.GameLogic.Models.Cards.Abstractions;

namespace MauMau.GameLogic.Models.Cards.NonDraw.Helpers;

public class HelperCard : NonDrawCard
{
    public HelperCard(Suit suit, Rank rank = Rank.Undefined) : base(rank, suit) { }
}