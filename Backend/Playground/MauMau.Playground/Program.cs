using MauMau.Common.Enums.Cards;
using MauMau.Core.GameComponents;
using MauMau.Core.GameComponents.Moves;
using MauMau.Core.GameComponents.Options;
using MauMau.Core.Identity;
using MauMau.Core.Players;
using MauMau.Core.ValueObjects;
using MauMau.DataAccess;
using MauMau.DataAccess.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

const string connectionString = "Server=(localdb)\\mssqllocaldb;Database=MauMau;Trusted_Connection=True;";

IServiceProvider services = new ServiceCollection()
    .AddDatabaseContext(o => o.UseSqlServer(connectionString))
    .BuildServiceProvider();

var context = services.GetRequiredService<MauMauDbContext>();

await context.Database.EnsureDeletedAsync();
await context.Database.EnsureCreatedAsync();

var adminRole = new Role("admin");
var userRole = new Role("user");

var player = new UserPlayer(300, DateTime.Now);

var adminUser1 = new User("1", "admin@mail.com", BCrypt.Net.BCrypt.HashPassword("123456", 10), adminRole, player);
var adminUser2 = new User("2", "fdsfdsfil.com", BCrypt.Net.BCrypt.HashPassword("432423", 10), adminRole, new UserPlayer(1, DateTime.UtcNow));
var simpleUser1 = new User("3", "31231.com", BCrypt.Net.BCrypt.HashPassword("321312", 10), userRole, new UserPlayer(2, DateTime.UtcNow));
var simpleUser2 = new User("4", "3232.com", BCrypt.Net.BCrypt.HashPassword("31231231", 10), userRole, new UserPlayer(3, DateTime.UtcNow));

var accessToken = new AccessToken(adminUser1, Guid.NewGuid().ToString(), DateTime.UtcNow);

await context.Roles.AddRangeAsync(adminRole, userRole);
await context.Users.AddRangeAsync(adminUser1, adminUser2, simpleUser1, simpleUser2);
await context.AccessTokens.AddAsync(accessToken);

await context.SaveChangesAsync();

var gameOptions = new GameOptions(100, 2, Rank.Six, 4, "6969");

gameOptions.AddPlayerPosition(new PlayerPosition(player, 1));

context.GameOptions.Add(gameOptions);

await context.SaveChangesAsync();


var hand = new Hand(player, new Cards(new List<Card> { new(Rank.Ace, Suit.Clubs), new(Rank.King, Suit.Spades) }));
var hand2 = new Hand(player, new Cards(new List<Card> { new(Rank.Ace, Suit.Clubs), new(Rank.Queen, Suit.Spades) }));
await context.Hands.AddRangeAsync(hand, hand2);

var moves = new List<Move>
{
    new CardMove(Guid.NewGuid(), hand, new Card(Rank.Six, Suit.Diamonds)),
    new DrawMove(Guid.NewGuid(), hand2),
    new SkipMove(Guid.NewGuid(), hand2),
    new PickSuitMove(Guid.NewGuid(), hand, Suit.Hearts)
};

var game = new Game(
    Guid.NewGuid(),
    1000,
    new Cards(),
    new Cards(),
    new []{ hand, hand2 },
    moves,
    0,
    true,
    150);

await context.Games.AddAsync(game);
await context.SaveChangesAsync();