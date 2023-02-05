using AutoMapper;
using MauMau.Abstractions.GameLogic.Models;
using MauMau.Application.Dto.Game;
using MauMau.GameLogic.Mapping.Converters;

namespace MauMau.GameLogic.Mapping.Profiles;

public class GameProfile : Profile
{
    public GameProfile()
    {
        CreateMap<IGame, GameDto>();

        CreateMap<GameDto, IGame>()
            .ConvertUsing<GameConverter>();
    }
}