using AutoMapper;
using MauMau.Abstractions.GameLogic.Models;
using MauMau.Abstractions.GameLogic.Models.Cards;
using MauMau.Application.Dto.Game;
using MauMau.GameLogic.Models;

namespace MauMau.GameLogic.Mapping.Profiles;

public class HandProfile : Profile
{
    public HandProfile()
    {
        CreateMap<IHand, HandDto>();

        CreateMap<HandDto, IHand>()
            .ConvertUsing((dto, _, context) =>
            {
                var cards = context.Mapper.Map<List<ICard>>(dto.Cards);
                return new Hand(dto.Id, dto.PlayerId, cards);
            });
    }
}