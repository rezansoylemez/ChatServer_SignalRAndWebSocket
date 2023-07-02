using ChatServer.GenericRepository;
using ChatServer.Models;
namespace ChatServer.Repositories;

public interface IMessageRepository: IEfRepositoryBase<Message>
{
}
