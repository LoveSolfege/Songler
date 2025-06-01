using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configuration;

public class SongConfig : IEntityTypeConfiguration<Song>
{
    public void Configure(EntityTypeBuilder<Song> builder) 
    {
        builder.HasKey(s => new { s.ArtistId, s.AlbumId, s.Id });
        
        builder.HasOne(s => s.Album)
            .WithMany(a => a.Songs)
            .HasForeignKey(s => new { s.ArtistId, s.AlbumId })
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasOne(s => s.Grade)
            .WithMany()
            .HasForeignKey(s => s.GradeId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}