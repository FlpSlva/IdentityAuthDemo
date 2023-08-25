using CustomerApi.Models;

namespace CustomerApi.Data;

public interface ICustomerRepository<T> where T : Entity
{
    Task Insert(Customer customer);
}
