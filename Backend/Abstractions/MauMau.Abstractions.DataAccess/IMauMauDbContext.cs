using MauMau.Core.GameComponents;
using MauMau.Core.GameComponents.Moves;
using MauMau.Core.GameComponents.Options;
using MauMau.Core.Identity;
using MauMau.Core.Players;
using Microsoft.EntityFrameworkCore;

namespace MauMau.Abstractions.DataAccess;

public interface IMauMauDbContext
{
    DbSet<User> Users { get; }
    DbSet<Role> Roles { get; }
    DbSet<AccessToken> AccessTokens { get; }
    
    DbSet<Friendship> Friendships { get; }

    DbSet<UserPlayer> UserPlayers { get; }
    DbSet<BotPlayer> BotPlayers { get; }

    DbSet<PlayerPosition> PlayerPositions { get; }
    DbSet<GameOptions> GameOptions { get; }

    DbSet<Game> Games { get; }
    DbSet<Hand> Hands { get; }

    DbSet<CardMove> CardMoves { get; }
    DbSet<DrawMove> DrawMoves { get; }
    DbSet<SkipMove> SkipMoves { get; }
    DbSet<PickSuitMove> PickSuitMoves { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}