using ChatServer.Context;
using ChatServer.GenericRepository;
using ChatServer.Models;

namespace ChatServer.Repositories;

public class UserRepository : EfRepositoryBase<User, BaseDbContext>, IUserRepository
{
    public UserRepository(BaseDbContext baseDbContext) : base(baseDbContext)
    {

    }
}
