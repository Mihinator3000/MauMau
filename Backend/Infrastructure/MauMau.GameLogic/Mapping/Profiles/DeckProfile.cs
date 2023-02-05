using AutoMapper;
using MauMau.Abstractions.GameLogic.Models;
using MauMau.Application.Dto.Game;
using MauMau.GameLogic.Mapping.Converters;

namespace MauMau.GameLogic.Mapping.Profiles;

public class DeckProfile : Profile
{
    public DeckProfile()
    {
        CreateMap<IDeck, CardsDto>();

        CreateMap<CardsDto, IDeck>()
            .ConvertUsing<DeckConverter>();
    }
}