using MauMau.Core.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MauMau.DataAccess.Configurations.Identity;

public class FriendshipConfiguration : IEntityTypeConfiguration<Friendship>
{
    public void Configure(EntityTypeBuilder<Friendship> builder)
    {
        builder.HasKey(f => new { f.SenderId, f.ReceiverId });

        builder
            .HasOne(f => f.Sender)
            .WithMany(u => u.OutgoingFriendRequests)
            .HasForeignKey(f => f.SenderId)
            .OnDelete(DeleteBehavior.Restrict);

        builder
            .HasOne(f => f.Receiver)
            .WithMany(u => u.IncomingFriendRequests)
            .HasForeignKey(f => f.ReceiverId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}