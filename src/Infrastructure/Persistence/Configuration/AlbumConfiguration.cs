using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configuration;

public class AlbumConfiguration : IEntityTypeConfiguration<Album>
{
    public void Configure(EntityTypeBuilder<Album> album)
    {
        album.HasKey(k => k.Id);
        
        album.Property(p => p.Id)
            .IsRequired()
            .HasDefaultValueSql("uuidv7()");
        
        album.Property(p => p.AlbumTitle)
            .IsRequired()
            .HasColumnType("varchar(200)")
            .HasMaxLength(200)
            .IsUnicode(true);
        
        album.Property(p => p.TimeAdded)
            .IsRequired()
            .HasColumnType("timestamptz");
            
        album.Property(a => a.IsDeleted)
            .HasDefaultValue(false);
        
        album.HasOne(al => al.Artist)
            .WithMany(at => at.Albums)
            .HasForeignKey(fk => fk.ArtistId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);
    }
}