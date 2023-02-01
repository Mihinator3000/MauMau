﻿using MauMau.Abstractions.GameLogic.Cards;
using MauMau.Common.Enums.Cards;
using MauMau.GameLogic.Cards.Abstractions;
using MauMau.GameLogic.Cards.Actions;

namespace MauMau.GameLogic.Cards.NonDraw;

public class QueenCard : NonDrawCard, IActionCard
{
    public QueenCard(Suit suit) : base(Rank.Queen, suit) { }

    public override int Weight => Suit is Suit.Spades ? 40 : 20;

    public override bool CanBePlayed(ICard previousCard)
        => previousCard is not DrawCard;

    public ICardAction GetCardAction()
        => NotChangeHandAction.Value;
}