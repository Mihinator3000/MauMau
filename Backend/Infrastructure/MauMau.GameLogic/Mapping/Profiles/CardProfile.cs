using AutoMapper;
using MauMau.Abstractions.GameLogic.Models.Cards;
using MauMau.Application.Dto.Game;
using MauMau.GameLogic.Mapping.Converters;

namespace MauMau.GameLogic.Mapping.Profiles;

public class CardProfile : Profile
{
    public CardProfile()
    {
        CreateMap<ICard, CardDto>();

        CreateMap<CardDto, ICard>()
            .ConvertUsing<CardConverter>();
    }
}