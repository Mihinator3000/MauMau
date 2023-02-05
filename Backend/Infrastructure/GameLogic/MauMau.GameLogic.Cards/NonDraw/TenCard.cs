using MauMau.Abstractions.GameLogic.Models.Cards;
using MauMau.Common.Enums.Cards;
using MauMau.GameLogic.Cards.Abstractions;
using MauMau.GameLogic.Cards.Actions;

namespace MauMau.GameLogic.Cards.NonDraw;

public class TenCard : NonDrawCard, IActionCard
{
    public TenCard(Suit suit) : base(Rank.Ten, suit) { }

    public ICardAction GetCardAction()
        => ChangeRotationAction.Value;
}