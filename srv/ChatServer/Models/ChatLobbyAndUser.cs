namespace ChatServer.Models;

public class ChatLobbyAndUser:Entity
{
    public int UserId { get; set; }
    public User User { get; set; }
    public int ChatLobbyId { get; set; }
    public ChatLobby ChatLobby { get; set; }
}
