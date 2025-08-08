using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configuration;

public class UserHiddenAlbumConfiguration : IEntityTypeConfiguration<UserHiddenAlbum>
{
    public void Configure(EntityTypeBuilder<UserHiddenAlbum> uha)
    {
        uha.HasKey(k => new {k.AlbumId, k.UserId});
        
        uha.HasOne(o => o.Album)
            .WithMany(m => m.UserHiddenAlbums)
            .HasForeignKey(o => o.AlbumId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);
        
        uha.HasOne(o => o.User)
            .WithMany(m => m.HiddenAlbums)
            .HasForeignKey(o => o.UserId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);
        
        uha.Property(p => p.DateHidden)
            .HasColumnType("timestamptz")
            .IsRequired();
    }
}