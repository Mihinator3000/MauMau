using MauMau.Core.Players;

namespace MauMau.Abstractions.Application.Factories;

public interface IUserPlayerFactory
{
    UserPlayer Create();
}