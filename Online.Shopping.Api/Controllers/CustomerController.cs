using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Online.Shopping.Application.Customers.Create;

namespace Online.Shopping.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
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
