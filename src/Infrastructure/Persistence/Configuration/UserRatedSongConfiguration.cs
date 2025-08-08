using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configuration;

public class UserRatedSongConfiguration : IEntityTypeConfiguration<UserRatedSong>
{
    public void Configure(EntityTypeBuilder<UserRatedSong> urs)
    {
        urs.HasKey(k => new {k.UserId, k.SongId});
        
        urs.HasOne(u => u.User)
            .WithMany(u => u.RatedSongs)
            .HasForeignKey(u => u.UserId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);
        
        urs.HasOne(u => u.Song)
            .WithMany(m => m.UserRatedSongs)
            .HasForeignKey(u => u.SongId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);

        urs.Property(p => p.Rating)
            .HasColumnType("smallint")
            .HasDefaultValue((short)0);
        
        urs.ToTable(t => 
            t.HasCheckConstraint("CK_UserRatedSong_Rating_Range", "\"Rating\" >= 0 AND \"Rating\" <= 100"));
        
    }
}