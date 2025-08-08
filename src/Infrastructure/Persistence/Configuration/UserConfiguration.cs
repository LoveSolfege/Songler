using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configuration;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> user)
    {
        user.HasKey(u => u.Id);
        
        user.Property(u => u.Id)
            .IsRequired()
            .HasDefaultValueSql("uuidv7()");
        
        user.Property(u => u.Email)
            .IsRequired()
            .HasColumnType("varchar(254)")
            .HasMaxLength(254)
            .IsUnicode();

        user.Property(u => u.PasswordHash)
            .IsRequired()
            .HasColumnType("text")
            .IsUnicode();
        
        user.Property(u => u.Role)
            .IsRequired()
            .HasColumnType("Role")
            .HasDefaultValue(Role.User);

        user.Property(u => u.IsDeleted)
            .HasDefaultValue(false);
        
        user.HasOne(u => u.UserData)
            .WithMany(d => d.Users)
            .HasForeignKey(u => u.UserDataId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);
    }
}