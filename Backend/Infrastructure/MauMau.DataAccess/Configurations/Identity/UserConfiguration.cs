using MauMau.Core.Identity;
using MauMau.Core.Players;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MauMau.DataAccess.Configurations.Identity;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasIndex(u => u.Name).IsUnique();
        builder.HasIndex(u => u.Email).IsUnique();

        builder.Navigation(u => u.Friendships).HasField("_friendships");
        builder.Navigation(u => u.OutgoingFriendRequests).HasField("_outgoingFriendRequests");
        builder.Navigation(u => u.IncomingFriendRequests).HasField("_incomingFriendRequests");

        builder
            .HasOne(u => u.AccessToken)
            .WithOne(t => t.User)
            .HasForeignKey<AccessToken>(t => t.UserId);

        builder
            .HasOne(u => u.Player)
            .WithOne(p => p.User)
            .HasForeignKey<UserPlayer>(p => p.UserId);
    }
}