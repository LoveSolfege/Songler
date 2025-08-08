using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configuration;

public class UserDataConfiguration : IEntityTypeConfiguration<UserData>
{
    public void Configure(EntityTypeBuilder<UserData> userData)
    {
        userData.HasKey(u => u.Id);
        
        userData.Property(u => u.Id)
            .IsRequired()
            .HasDefaultValueSql("uuidv7()");
        
        userData.Property(u => u.Name)
            .IsRequired()
            .HasColumnType("varchar(50)")
            .HasMaxLength(50);
        
        userData.Property(u => u.Surname)
            .IsRequired()
            .HasColumnType("varchar(50)")
            .HasMaxLength(50);
        
        userData.Property(u => u.DateCreated)
            .IsRequired()
            .HasColumnType("timestamptz");
        
        userData.HasOne(u => u.UserDataHistory)
            .WithOne(u => u.UserData)
            .HasForeignKey<UserDataHistory>(u => u.Id)
            .OnDelete(DeleteBehavior.Restrict);
    }
}