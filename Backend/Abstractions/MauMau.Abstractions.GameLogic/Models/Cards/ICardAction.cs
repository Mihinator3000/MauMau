namespace MauMau.Abstractions.GameLogic.Models.Cards;

public interface ICardAction
{
    void Apply(IGame game);
}