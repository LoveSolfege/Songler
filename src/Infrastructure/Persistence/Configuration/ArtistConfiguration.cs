using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configuration;

public class ArtistConfiguration : IEntityTypeConfiguration<Artist>
{
    public void Configure(EntityTypeBuilder<Artist> artist)
    {
        artist.HasKey(a => a.Id);

        artist.Property(a => a.Id)
            .IsRequired()
            .HasDefaultValueSql("uuidv7()");
        
        artist.Property(a => a.ArtistName)
            .IsRequired()
            .HasColumnType("varchar(200)")
            .HasMaxLength(200)
            .IsUnicode(true);
        
        artist.Property(a => a.TimeAdded)
            .IsRequired()
            .HasColumnType("timestamptz");
        
        artist.Property(a => a.IsDeleted)
            .HasDefaultValue(false);
    }
}