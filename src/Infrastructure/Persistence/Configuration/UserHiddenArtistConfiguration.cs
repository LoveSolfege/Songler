using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configuration;

public class UserHiddenArtistConfiguration : IEntityTypeConfiguration<UserHiddenArtist>
{
    public void Configure(EntityTypeBuilder<UserHiddenArtist> uha)
    {
        uha.HasKey(k => new {k.ArtistId, k.UserId});
        
        uha.HasOne(u => u.Artist)
            .WithMany(m =>  m.UserHiddenArtists)
            .HasForeignKey(u => u.ArtistId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);
        
        uha.HasOne(u => u.User)
            .WithMany(m => m.HiddenArtists)
            .HasForeignKey(u => u.UserId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);
        
        uha.Property(p => p.DateHidden)
            .HasColumnType("timestamptz")
            .IsRequired();
    }
}
