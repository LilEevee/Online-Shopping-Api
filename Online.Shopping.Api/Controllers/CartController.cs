using MediatR;
using Microsoft.AspNetCore.Mvc;
using Online.Shopping.Application.Carts.AddLineItem;
using Online.Shopping.Application.Carts.Create;
using Online.Shopping.Application.Carts.RemoveLineItem;
using Online.Shopping.Domain.Carts;
using Online.Shopping.Domain.Products;

// TODO : FIX ERROR HANDLING

namespace Online.Shopping.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger _logger;

        public CartController(ILogger logger, IMediator mediator)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpPost("CreateCart")]
        public async Task<IActionResult> CreateCart(Guid customerId)
        {
            var createCartCommand = new CreateCartCommand(customerId);

            await _mediator.Send(createCartCommand);

            return Ok();
        }

        [HttpPut("AddLineItemToCart")]
        public async Task<IActionResult> AddLineItemToCart([FromBody] AddLineItemRequest addLineItemRequest)
        {
            var addLineItemCommand = new AddLineItemCommand(new CartId(addLineItemRequest.CartId), new ProductId(addLineItemRequest.ProductId),
                addLineItemRequest.Currency, addLineItemRequest.Amount);

            await _mediator.Send(addLineItemCommand);

            return Ok();
        }

        [HttpDelete("RemoveLineItemFromCart")]
        public async Task<IActionResult> RemoveLineItemFromCart([FromBody] RemoveLineItemRequest removeLineItemRequest)
        {
            var removeLineItemCommand = new RemoveLineItemCommand(new CartId(removeLineItemRequest.CartId), new LineItemId(removeLineItemRequest.LineItemId));

            await _mediator.Send(removeLineItemCommand);

            return Ok();
        }
    }
}
