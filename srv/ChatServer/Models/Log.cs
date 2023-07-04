namespace ChatServer.Models;

public class Log:Entity
{ 
    public string LogMessage { get; set; }
    public int MessageId { get; set; }       

     
    public Message Message { get; set; }  

    public Log()
    {
    }

    public Log(int id ,string logMessage, int messageId, Message message):this() 
    {
        LogMessage = logMessage;
        MessageId = messageId;
        Message = message;
    }
}
