using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configuration;

public class SongConfiguration : IEntityTypeConfiguration<Song>
{
    public void Configure(EntityTypeBuilder<Song> song)
    {
        song.HasKey(s => s.Id);
        
        song.Property(s => s.Id)
            .IsRequired()
            .HasDefaultValueSql("uuidv7()");

        song.Property(s => s.SongTitle)
            .IsRequired()
            .HasColumnType("varchar(200)")
            .HasMaxLength(200)
            .IsUnicode();
        
        song.Property(s => s.TimeAdded)
            .IsRequired()
            .HasColumnType("timestamptz");
        
        song.Property(s => s.IsDeleted)
            .HasDefaultValue(false);

        song.HasOne(s => s.Album)
            .WithMany(a => a.Songs)
            .HasForeignKey(fk => fk.AlbumId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);
    }
}