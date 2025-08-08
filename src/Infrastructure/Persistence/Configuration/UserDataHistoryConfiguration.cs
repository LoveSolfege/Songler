using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configuration;

public class UserDataHistoryConfiguration : IEntityTypeConfiguration<UserDataHistory>
{
    public void Configure(EntityTypeBuilder<UserDataHistory> userDataHistory)
    {
        userDataHistory.HasKey(s => s.Id);
        
        userDataHistory.Property(u => u.Id)
            .HasColumnName("UserDataId");

        userDataHistory.Property(u => u.UserId)
            .IsRequired();
        
        userDataHistory.Property(u => u.UserName)
            .IsRequired()
            .HasColumnType("varchar(50)")
            .HasMaxLength(50);
        
        userDataHistory.Property(u => u.UserSurname)
            .IsRequired()
            .HasColumnType("varchar(50)")
            .HasMaxLength(50);
        
        userDataHistory.Property(u => u.UserUsername)
            .IsRequired()
            .HasColumnType("varchar(50)")
            .HasMaxLength(50)
            .IsUnicode();
        
        userDataHistory.Property(u => u.UserEmail)
            .IsRequired()
            .HasColumnType("varchar(254)")
            .HasMaxLength(254)
            .IsUnicode();

        userDataHistory.Property(u => u.UserPasswordHash)
            .IsRequired()
            .HasColumnType("text")
            .IsUnicode();

        userDataHistory.Property(u => u.TimeChanged)
            .IsRequired()
            .HasColumnType("timestamptz");
    }
}