namespace ChatServer.Models;

public class Log:Entity
{
    public string LogName { get; set; }

    public int ChatLobbyId { get; set; }
    public ChatLobby ChatLobby { get; set; }
}
