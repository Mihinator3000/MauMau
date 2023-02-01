using AutoMapper;
using MauMau.Abstractions.GameLogic.Cards;
using MauMau.Abstractions.GameLogic.Factories;
using MauMau.Application.Dto.Game;

namespace MauMau.GameLogic.Mapping.Converters;

public class CardConverter : ITypeConverter<CardDto, ICard>
{
    private readonly ICardFactory _cardFactory;

    public CardConverter(ICardFactory cardFactory)
    {
        _cardFactory = cardFactory;
    }

    public ICard Convert(CardDto dto, ICard destination, ResolutionContext context)
        => _cardFactory.Create(dto.Rank, dto.Suit);
}