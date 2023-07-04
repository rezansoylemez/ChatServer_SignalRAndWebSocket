using ChatServer.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace ChatServer.EntityConfiguration;

public class MessageConfiguration : IEntityTypeConfiguration<Message>
{
    public void Configure(EntityTypeBuilder<Message> builder)
    {
        builder.ToTable("Message").HasKey(o => o.Id);

        //builder.HasOne(x => x.User).WithMany(x => x.Logs).HasForeignKey(x => x.UserId);

        //builder.HasOne(x => x.Message).WithMany(x => x.Logs).HasForeignKey(x => x.MessageId);

        builder.HasOne(x => x.Log).WithOne(x => x.Message).HasForeignKey<Message>(x => x.Id);

      //  builder.HasOne(x => x.User);

        builder.HasOne(x => x.User);


    }
}

