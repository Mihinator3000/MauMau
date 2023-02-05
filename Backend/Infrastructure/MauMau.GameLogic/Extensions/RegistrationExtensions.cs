using MauMau.Abstractions.GameLogic.Factories;
using MauMau.Abstractions.GameLogic.Providers;
using MauMau.GameLogic.Factories;
using MauMau.GameLogic.Providers;
using Microsoft.Extensions.DependencyInjection;

namespace MauMau.GameLogic.Extensions;

public static class RegistrationExtensions
{
    public static IServiceCollection AddGameLogic(this IServiceCollection services)
    {
        services
            .AddScoped<IRandomProvider, RandomProvider>()
            .AddScoped<ICardFactory, CardFactory>()
            .AddScoped<IDeckFactory, DeckFactory>()
            .AddScoped<IGameFactory, GameFactory>();
        
        services.AddAutoMapper(typeof(IAssemblyMarker));

        return services;
    }
}