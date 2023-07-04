using ChatServer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChatServer.EntityConfiguration;

public class LogConfiguration : IEntityTypeConfiguration<Log>
{
    public void Configure(EntityTypeBuilder<Log> builder)
    {
        builder.ToTable("MessageLogs"); 
        builder.HasKey(ml => ml.Id);  
        builder.Property(ml => ml.LogMessage).IsRequired();   
         
        builder.HasOne(ml => ml.Message)
               .WithMany()
               .HasForeignKey(ml => ml.MessageId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}
