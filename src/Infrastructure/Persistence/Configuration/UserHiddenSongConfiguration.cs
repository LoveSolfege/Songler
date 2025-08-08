using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configuration;

public class UserHiddenSongConfiguration : IEntityTypeConfiguration<UserHiddenSong>
{
    public void Configure(EntityTypeBuilder<UserHiddenSong> uhs)
    {
        uhs.HasKey(k => new { k.SongId, k.UserId });
        
        uhs.HasOne(u => u.Song)
            .WithMany(m => m.UserHiddenSongs)
            .HasForeignKey(u => u.SongId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);
        
        uhs.HasOne(u => u.User)
            .WithMany(m => m.HiddenSongs)
            .HasForeignKey(u => u.UserId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);
        
        uhs.Property(p => p.DateHidden)
            .HasColumnType("timestamptz")
            .IsRequired();
    }
}