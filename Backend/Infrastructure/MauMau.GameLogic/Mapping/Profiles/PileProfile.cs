using AutoMapper;
using MauMau.Abstractions.GameLogic.Models;
using MauMau.Abstractions.GameLogic.Models.Cards;
using MauMau.Application.Dto.Game;
using MauMau.GameLogic.Models;

namespace MauMau.GameLogic.Mapping.Profiles;

public class PileProfile : Profile
{
    public PileProfile()
    {
        CreateMap<IPile, CardsDto>();

        CreateMap<CardsDto, IPile>()
            .ConvertUsing((dto, _, context) =>
            {
                var cards = context.Mapper.Map<List<ICard>>(dto.Cards);
                return new Pile(cards);
            });
    }
}