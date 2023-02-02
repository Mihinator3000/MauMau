using MauMau.Abstractions.Application.Factories;
using MauMau.Abstractions.Application.Providers;
using MauMau.Abstractions.Application.Services;
using MauMau.Application.Factories;
using MauMau.Application.Providers;
using MauMau.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace MauMau.Application.Extensions;

public static class RegistrationExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services
            .AddSingleton<IDateTimeProvider, UtcDateTimeProvider>()
            .AddSingleton<IPasswordEncoder, BCryptPasswordEncoder>()
            .AddSingleton<IAccessTokenFactory, AccessTokenFactory>()
            .AddSingleton<IUserPlayerFactory, UserPlayerFactory>();

        return services;
    }
}