using MauMau.Core.GameComponents.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MauMau.DataAccess.Configurations.GameComponents;

public class GameOptionsConfiguration : IEntityTypeConfiguration<GameOptions>
{
    public void Configure(EntityTypeBuilder<GameOptions> builder)
    {
        builder.Navigation(o => o.PlayerPositions).HasField("_playerPositions");
    }
}