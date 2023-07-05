namespace ChatServer.Models
{
    public class ChatLobby:Entity
    {
        public ICollection<ChatLobbyAndUser> ChatLobbyAndUsers { get; set; }
        public ICollection<Message> Messages{ get; set; }
        public ICollection<Log> Logs{ get; set; }

        public ChatLobby()
        {
              
        }
    }
}
