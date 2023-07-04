using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using ChatServer.Models;

namespace ChatServer.EntityConfiguration;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users");  
        builder.HasKey(u => u.Id);  
        builder.Property(u => u.FirstName).IsRequired().HasMaxLength(50);  

        builder.Property(u => u.LastName).IsRequired().HasMaxLength(50);  
         
        builder.HasMany(u => u.Messages)
               .WithOne(m => m.User)
               .HasForeignKey(m => m.UserId)
               .OnDelete(DeleteBehavior.Cascade);


    }
}

