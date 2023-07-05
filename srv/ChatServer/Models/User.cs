namespace ChatServer.Models;
public class User:Entity
{
    public string FirstName { get; set; }
    public string LastName { get; set; }


    public ICollection<Message> Messages { get; set; }
    public ICollection<ChatLobbyAndUser> ChatLobbyAndUsers { get; set; }

    public User()
    {
        ChatLobbyAndUsers = new HashSet<ChatLobbyAndUser>( );

    }
    public User(int id ,string firstName, string lastName):this()
    {   
        Id = id ;
        FirstName = firstName;
        LastName = lastName;
    }
}

