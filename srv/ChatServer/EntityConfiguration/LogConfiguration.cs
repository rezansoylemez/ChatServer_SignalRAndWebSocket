using ChatServer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChatServer.EntityConfiguration;

public class LogConfiguration : IEntityTypeConfiguration<Log>
{
    public void Configure(EntityTypeBuilder<Log> builder)
    {
        builder.ToTable("Logs");
        builder.HasKey(log => log.Id);
        builder.Property(log => log.ChatLobbyId).IsRequired(); 
         

        builder.HasOne(log => log.ChatLobby)
            .WithMany(m => m.Logs)
            .HasForeignKey(log => log.ChatLobbyId);

    }
}
