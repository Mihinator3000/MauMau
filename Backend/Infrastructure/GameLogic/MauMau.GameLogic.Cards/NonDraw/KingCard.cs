﻿using MauMau.Common.Enums.Cards;
using MauMau.GameLogic.Cards.Abstractions;

namespace MauMau.GameLogic.Cards.NonDraw;

public class KingCard : NonDrawCard
{
    public KingCard(Suit suit) : base(Rank.King, suit) { }

    public override int Weight => 4;
}