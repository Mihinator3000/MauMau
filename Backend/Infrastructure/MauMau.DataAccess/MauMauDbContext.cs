using MauMau.Abstractions.DataAccess;
using MauMau.Core.GameComponents;
using MauMau.Core.GameComponents.Options;
using MauMau.Core.Identity;
using MauMau.Core.Players;
using MauMau.Core.ValueObjects;
using MauMau.DataAccess.ValueConverters;
using Microsoft.EntityFrameworkCore;

namespace MauMau.DataAccess;

public class MauMauDbContext : DbContext, IMauMauDbContext
{
    public MauMauDbContext(DbContextOptions options) : base(options) { }

    public required DbSet<User> Users { get; init; }
    public required DbSet<Role> Roles { get; init; }
    public required DbSet<AccessToken> AccessTokens { get; init; }

    public required DbSet<Friendship> Friendships { get; init; }

    public required DbSet<UserPlayer> UserPlayers { get; init; }
    public required DbSet<BotPlayer> BotPlayers { get; init; }

    public required DbSet<PlayerPosition> PlayerPositions { get; init; }
    public required DbSet<GameOptions> GameOptions { get; init; }

    public required DbSet<Game> Games { get; init; }
    public required DbSet<Hand> Hands { get; init; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(IAssemblyMarker).Assembly);
    }

    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        configurationBuilder.Properties<Cards>().HaveConversion<CardsConverter>();
        configurationBuilder.Properties<TimeSpan>().HaveConversion<TimeSpanConverter>();
    }
}