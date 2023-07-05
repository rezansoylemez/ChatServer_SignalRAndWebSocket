namespace ChatServer.Models
{
    public class ChatLobby:Entity
    {
        public ICollection<ChatLobbyAndUser> ChatLobbyAndUsers { get; set; }

        public ChatLobby()
        {
              
        }
    }
}
