using CustomerApi.Data;
using CustomerApi.Models;
using Microsoft.EntityFrameworkCore;

namespace CustomerApi.Repository;

public class CustomerRepository : ICustomerRepository<Customer>
{
    private readonly CustomerContext _context;
    public CustomerRepository(CustomerContext context)
        => _context = context;

    public async Task Insert(Customer customer)
    {

       await _context.Customers.AddAsync(customer);
       await _context.SaveChangesAsync();
    }

}
