using CustomerApi.Data;
using CustomerApi.Dtos;
using CustomerApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace CustomerApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CustomerController : ControllerBase
{
    private readonly ICustomerRepository<Customer> _repository;

    public CustomerController(ICustomerRepository<Customer> repository)
        => _repository = repository;

    [HttpPost("register")]
    public async Task<ActionResult> Register(UserRegisterDTO user)
    {
        var customer = new Customer(user.Name, user.Email);
        customer.AssignId(user.Id);

       await _repository.Insert(customer);
        return Ok(customer);
    }
}
