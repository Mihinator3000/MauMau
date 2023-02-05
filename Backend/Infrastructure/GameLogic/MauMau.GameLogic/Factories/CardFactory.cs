using MauMau.Abstractions.GameLogic.Factories;
using MauMau.Abstractions.GameLogic.Models.Cards;
using MauMau.Common.Enums.Cards;
using MauMau.GameLogic.Cards.Draw;
using MauMau.GameLogic.Cards.NonDraw;

namespace MauMau.GameLogic.Factories;

public class CardFactory : ICardFactory
{
    public ICard Create(Rank rank, Suit suit)
    {
        return rank switch
        {
            Rank.Six => new SixCard(suit),
            Rank.Seven => new SevenCard(suit),
            Rank.Eight => new EightCard(suit),
            Rank.Nine => new NineCard(suit),
            Rank.Ten => new TenCard(suit),
            Rank.Jack => new JackCard(suit),
            Rank.Queen => new QueenCard(suit),
            Rank.King => CreateKingCard(suit),
            Rank.Ace => new AceCard(suit),
            _ => new RegularCard(rank, suit)
        };
    }

    private static ICard CreateKingCard(Suit suit)
    {
        return suit is Suit.Spades
            ? new KingOfSpadesCard()
            : new KingCard(suit);
    }
}