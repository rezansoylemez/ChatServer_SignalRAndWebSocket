using ChatServer.Context;
using ChatServer.GenericRepository;
using ChatServer.Models;

namespace ChatServer.Repositories;

public class MessageRepository:EfRepositoryBase<Message, BaseDbContext>, IMessageRepository
{
    public MessageRepository(BaseDbContext baseDbContext):base(baseDbContext)
    {
            
    }
}
