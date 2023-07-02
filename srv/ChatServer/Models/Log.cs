namespace ChatServer.Models;

public class Log:Entity
{
    public  int MessageId { get; set; }
    public int UserId { get; set; }


    public User User{ get; set; }
    public Message Message { get; set; }

    public Log()
    {
    }
    public Log(int id ,int messageId, int userId, User user):this()
    {
        Id = id; 
        MessageId = messageId;
        UserId = userId;
        User = user;
    }
}
