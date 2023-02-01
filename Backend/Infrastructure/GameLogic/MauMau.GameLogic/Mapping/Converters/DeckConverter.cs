using AutoMapper;
using MauMau.Abstractions.GameLogic.Cards;
using MauMau.Abstractions.GameLogic.Models;
using MauMau.Abstractions.GameLogic.Providers;
using MauMau.Application.Dto.Game;
using MauMau.GameLogic.Models;

namespace MauMau.GameLogic.Mapping.Converters;

public class DeckConverter : ITypeConverter<CardsDto, IDeck>
{
    private readonly IRandomProvider _randomProvider;

    public DeckConverter(IRandomProvider randomProvider)
    {
        _randomProvider = randomProvider;
    }

    public IDeck Convert(CardsDto dto, IDeck destination, ResolutionContext context)
    {
        var cards = context.Mapper.Map<List<ICard>>(dto.Cards);
        return new Deck(cards, _randomProvider.GetRandom());
    }
}