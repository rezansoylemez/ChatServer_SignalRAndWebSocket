using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using ChatServer.Models;

namespace ChatServer.Context;

public class BaseDbContext: DbContext
{
    protected IConfiguration Configuration { get; set; }

    public DbSet<Message> Messages { get; set; }
    public BaseDbContext(DbContextOptions dbContextOptions, IConfiguration configuration) : base(dbContextOptions)
    {
        Configuration = configuration;
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {

        IEnumerable<EntityEntry<Entity>> entries = ChangeTracker
          .Entries<Entity>()
          .Where(e => e
          .State == EntityState
          .Added || e
          .State == EntityState
          .Modified);


        foreach (var entry in entries)
        {
            _ = entry.State switch
            {
                EntityState.Added => entry.Entity.CreatedDate = DateTime.UtcNow,
                EntityState.Modified => entry.Entity.UpdatedDate = DateTime.UtcNow
            };
        }
        return await base.SaveChangesAsync(cancellationToken);
    }

    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //{
    //    if (!optionsBuilder.IsConfigured)
    //        base.OnConfiguring(
    //            optionsBuilder.UseSqlServer(Configuration.GetConnectionString("FrostlineGamesWebConnection")));
    //}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly()); 
    }
}
