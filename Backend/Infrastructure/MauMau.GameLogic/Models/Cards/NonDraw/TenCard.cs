using MauMau.Abstractions.GameLogic.Models.Cards;
using MauMau.Common.Enums.Cards;
using MauMau.GameLogic.Models.Cards.Abstractions;
using MauMau.GameLogic.Models.Cards.Actions;

namespace MauMau.GameLogic.Models.Cards.NonDraw;

public class TenCard : NonDrawCard, IActionCard
{
    public TenCard(Suit suit) : base(Rank.Ten, suit) { }

    public ICardAction GetCardAction()
        => ChangeRotationAction.Value;
}