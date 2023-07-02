namespace ChatServer.Models;
public class Message:Entity
{
    public string User { get; set; }
    public string MessageBody { get; set; }

    public Message()
    {
            
    }
    public Message(int id,string user, string messageBody):this()
    {
        Id = id;
        User = user;
        MessageBody = messageBody;
    }
}
