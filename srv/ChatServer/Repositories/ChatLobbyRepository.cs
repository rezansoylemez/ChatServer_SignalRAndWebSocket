using ChatServer.Context;
using ChatServer.GenericRepository;
using ChatServer.Models;

namespace ChatServer.Repositories;
public class ChatLobbyRepository : EfRepositoryBase<ChatLobby, BaseDbContext>, IChatLobbyRepository
{
    public ChatLobbyRepository(BaseDbContext baseDbContext) : base(baseDbContext)
    {

    }
} 
