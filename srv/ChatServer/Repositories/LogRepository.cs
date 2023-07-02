using ChatServer.Context;
using ChatServer.GenericRepository;
using ChatServer.Models;

namespace ChatServer.Repositories;
public class LogRepository : EfRepositoryBase<Log, BaseDbContext>, ILogRepository
{
    public LogRepository(BaseDbContext baseDbContext) : base(baseDbContext)
    {

    }
}
