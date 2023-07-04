using ChatServer.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace ChatServer.EntityConfiguration;

public class MessageConfiguration : IEntityTypeConfiguration<Message>
{
    public void Configure(EntityTypeBuilder<Message> builder)
    {
        builder.ToTable("Messages"); 
        builder.HasKey(m => m.Id); 
        builder.Property(m => m.Headers).IsRequired(); 
        builder.Property(m => m.Body).IsRequired(); 

        // İlişkili tablo ve ilişkiyi belirtin
        builder.HasOne(m => m.User)
               .WithMany(u => u.Messages)
               .HasForeignKey(m => m.UserId)
               .OnDelete(DeleteBehavior.Cascade);


    }
}

