using AutoMapper;
using MauMau.Abstractions.GameLogic.Cards;
using MauMau.Abstractions.GameLogic.Models;
using MauMau.Application.Dto.Game;
using MauMau.Common.Enums.Cards;
using MauMau.Common.Exceptions;
using MauMau.GameLogic.Models.Moves;
using Newtonsoft.Json;

namespace MauMau.GameLogic.Mapping.Profiles;

public class MoveProfile : Profile
{
    public MoveProfile()
    {
        CreateMap<MoveDto, IMove>()
            .ConvertUsing((dto, _, context) => dto.Type switch
            {
                nameof(DrawMove) => new DrawMove(dto.HandId),
                nameof(SkipMove) => new SkipMove(dto.HandId),
                nameof(CardMove) => ConvertCardMoveFromDto(dto, context),
                nameof(PickSuitMove) => ConvertPickSuitMoveFromDto(dto),
                _ => throw new ConversionException()
            });

        CreateMap<IMove, MoveDto>()
            .ConvertUsing((move, _, context) =>
            {
                string? value = move switch
                {
                    CardMove cardMove => JsonConvert.SerializeObject(context.Mapper.Map<CardDto>(cardMove.Card)),
                    PickSuitMove pickSuitMove => pickSuitMove.Suit.ToString(),
                    _ => null
                };

                return new MoveDto(move.GetType().Name, move.HandId, value);
            });
    }

    private static IMove ConvertCardMoveFromDto(MoveDto moveDto, IMapperBase mapper)
    {
        if (moveDto.Value is null)
            throw new ConversionException();

        var cardDto = JsonConvert.DeserializeObject<CardDto>(moveDto.Value);
        var card = mapper.Map<ICard>(cardDto);
        return new CardMove(moveDto.HandId, card);
    }

    private static IMove ConvertPickSuitMoveFromDto(MoveDto moveDto)
    {
        if (!Enum.TryParse(moveDto.Value, out Suit suit))
            throw new ConversionException();

        return new PickSuitMove(moveDto.HandId, suit);
    }
}