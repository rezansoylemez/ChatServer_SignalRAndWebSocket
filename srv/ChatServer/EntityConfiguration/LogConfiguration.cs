using ChatServer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChatServer.EntityConfiguration;

public class LogConfiguration : IEntityTypeConfiguration<Log>
{
    public void Configure(EntityTypeBuilder<Log> builder)
    {
        builder.ToTable("Log").HasKey(o => o.Id);

        builder.HasOne(x => x.Message).WithOne(x => x.Log).HasForeignKey<Log>(x => x.MessageId);
          
        //builder.HasOne(x => x.Message).WithMany(x => x.Logs).HasForeignKey(x => x.MessageId);

         
        
    }
}
