namespace CustomerApi.Models;

public abstract class Entity
{
    public Entity()
    {
        Id = Guid.NewGuid();
        CreatedAt = DateTime.Now;
    }
    public Guid Id { get; protected set; }
    public DateTime CreatedAt { get; protected set; }
}
