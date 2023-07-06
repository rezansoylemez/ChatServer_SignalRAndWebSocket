using ChatServer.Context;
using ChatServer.GenericRepository;
using ChatServer.Models;

namespace ChatServer.Repositories;
public class ChatLobbyAndUserRepository : EfRepositoryBase<ChatLobbyAndUser, BaseDbContext>, IChatLobbyAndUserRepository
{
    public ChatLobbyAndUserRepository(BaseDbContext baseDbContext) : base(baseDbContext)
    {

    }
}  
