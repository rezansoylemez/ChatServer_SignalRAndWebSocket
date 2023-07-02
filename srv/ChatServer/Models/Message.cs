namespace ChatServer.Models;
public class Message:Entity
{
    public string UserFirstName { get; set; }
    public string UserLastName { get; set; }
    public string MessageBody { get; set; }

    public Message()
    {
            
    }
    public Message(int id,string userFirstName,string userLastName, string messageBody):this()
    {
        Id = id;
        UserFirstName = userFirstName;
        userLastName = userLastName;
        MessageBody = messageBody;
    }
}
