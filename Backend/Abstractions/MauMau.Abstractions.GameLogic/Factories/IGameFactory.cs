using MauMau.Abstractions.GameLogic.Models;
using MauMau.Application.Dto.Game.Creation;

namespace MauMau.Abstractions.GameLogic.Factories;

public interface IGameFactory
{
    IGame Create(GameCreationDto gameCreationDto);
}