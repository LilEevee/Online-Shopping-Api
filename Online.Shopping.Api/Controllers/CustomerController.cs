using MediatR;
using Microsoft.AspNetCore.Mvc;
using Online.Shopping.Api.Requests.Customer;
using Online.Shopping.Application.Customers.Create;
using Online.Shopping.Domain.Customers;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Online.Shopping.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger _logger;

        public CustomerController(ILogger logger, IMediator mediator)
        {
            _mediator = mediator;
            _logger = logger;
        }

        // GET: api/<CustomerController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // POST api/<CustomerController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateCustomerRequest createCustomerRequest)
        {
            var createCustomerCommand = new CreateCustomerCommand(createCustomerRequest.Name, createCustomerRequest.Email);

            await _mediator.Send(createCustomerCommand);

            return Ok();
        }
    }
}
