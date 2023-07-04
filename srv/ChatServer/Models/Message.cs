namespace ChatServer.Models;
public class Message:Entity
{
    public string Headers { get; set; }
    public string Body { get; set; }


    public int UserId { get; set; } 

    public User User { get; set; } 
    public Log Log { get; set; } 
     
    public Message()
    { 
    }
    public Message(int id,int userId, User user , string body,string headers):this()
    {
        Id = id;
        UserId = userId;
        User = user;
        Body = body;
        Headers = headers;
    }
}
