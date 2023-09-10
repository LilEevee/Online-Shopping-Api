using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Online.Shopping.Application.Customers.Create;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Online.Shopping.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CustomerController(IMediator mediator)
        {
            _mediator = mediator;

        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateCustomerRequest createCustomerRequest)
        {
            var createCustomerCommand = new CreateCustomerCommand(createCustomerRequest.Name, createCustomerRequest.Surname, createCustomerRequest.Email);

           var createCustomerResponse = await _mediator.Send(createCustomerCommand);

            return Ok(createCustomerResponse);
        }
    }
}
