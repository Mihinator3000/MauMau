using MauMau.Abstractions.DataAccess;
using MauMau.Core.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace MauMau.DataAccess.Extensions;

public static class RegistrationExtensions
{
    private static readonly string[] DefaultRoles = { "User", "Admin" };

    public static IServiceCollection AddDatabaseContext(
        this IServiceCollection services,
        Action<DbContextOptionsBuilder> action)
    {
        services.AddDbContext<IMauMauDbContext, MauMauDbContext>(action);
        return services;
    }

    public static Task UseDatabaseContext(this IServiceProvider services)
    {
        var context = services.GetRequiredService<MauMauDbContext>();
        return context.Database.EnsureCreatedAsync();
    }

    public static async Task ConfigureDefaultRoles(this IServiceProvider services)
    {
        var context = services.GetRequiredService<IMauMauDbContext>();

        foreach (string roleName in DefaultRoles)
        {
            if (await context.Roles.AnyAsync(r => r.Name == roleName))
                continue;

            var role = new Role(roleName);
            await context.Roles.AddAsync(role);
        }

        await context.SaveChangesAsync();
    }
}