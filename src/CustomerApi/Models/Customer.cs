namespace CustomerApi.Models;

public class Customer : Entity
{
    public Customer(string name, string email)
        : base ()
    {
        Name = name;
        Email = email;
    }
    public string Name { get; private set; }
    public string Email { get; private set; }

    public void AssignId(Guid id)
    {
        if (id != Guid.Empty)
        {
            Id = id;
        }
    }
}
