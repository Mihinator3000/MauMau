using AutoMapper;
using MauMau.Abstractions.GameLogic.Models;
using MauMau.Abstractions.GameLogic.Providers;
using MauMau.Application.Dto.Game;
using MauMau.GameLogic.Models;

namespace MauMau.GameLogic.Mapping.Converters;

public class GameConverter : ITypeConverter<GameDto, IGame>
{
    private readonly IRandomProvider _randomProvider;

    public GameConverter(IRandomProvider randomProvider)
    {
        _randomProvider = randomProvider;
    }

    public IGame Convert(GameDto dto, IGame destination, ResolutionContext context)
    {
        var mapper = context.Mapper;

        var hands = mapper.Map<List<IHand>>(dto.Hands);
        var deck = mapper.Map<IDeck>(dto.Deck);
        var pile = mapper.Map<IPile>(dto.Pile);
        var moves = mapper.Map<List<IMove>>(dto.Moves);

        var random = _randomProvider.GetRandom();

        return new Game(
            dto.Id,
            dto.WinMoney,
            hands,
            deck,
            pile,
            moves,
            random,
            dto.MovesLeftCount,
            dto.CurrentHandNumber,
            dto.IsRotationClockWise);
    }
}