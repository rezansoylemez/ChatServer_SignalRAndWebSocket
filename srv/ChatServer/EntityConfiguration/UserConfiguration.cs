using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using ChatServer.Models;

namespace ChatServer.EntityConfiguration;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("User").HasKey(o => o.Id);

        //builder.HasOne(x => x.User).WithMany(x => x.Logs).HasForeignKey(x => x.UserId);

        //builder.HasOne(x => x.Message).WithMany(x => x.Logs).HasForeignKey(x => x.MessageId);
         

    }
}

