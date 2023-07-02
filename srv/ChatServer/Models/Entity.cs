namespace ChatServer.Models;
public class Entity
{
    public int Id { get; set; }
    public string? Code { get; set; }
    public bool Status { get; set; }
    public DateTime? CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }
    public DateTime? DeletedDate { get; set; }
    public Entity()
    {
    }

    public Entity(int id, string code)
    {
        Id = id;
        Code = code;
    }
}
