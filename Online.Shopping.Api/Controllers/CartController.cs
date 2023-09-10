using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Online.Shopping.Application.Carts.AddLineItem;
using Online.Shopping.Application.Carts.Create;
using Online.Shopping.Application.Carts.Get;
using Online.Shopping.Application.Carts.RemoveLineItem;
using Online.Shopping.Domain.Carts;
using Online.Shopping.Domain.Products;

namespace Online.Shopping.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CartController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Authorize]
        [HttpPost("CreateCart")]
        public async Task<IActionResult> CreateCart(Guid customerId)
        {
            var createCartCommand = new CreateCartCommand(customerId);

            var createCartResponse = await _mediator.Send(createCartCommand);

            return Ok(createCartResponse);
        }

        [Authorize]
        [HttpGet("GetCart")]
        public async Task<IActionResult> GetCart(Guid cartId)
        {
            var getCartCommand = new GetCartQuery(cartId);

            var getCartResponse = await _mediator.Send(getCartCommand);

            return Ok(getCartResponse);
        }

        [Authorize]
        [HttpPut("AddLineItemToCart")]
        public async Task<IActionResult> AddLineItemToCart([FromBody] AddLineItemRequest addLineItemRequest)
        {
            var addLineItemCommand = new AddLineItemCommand(new CartId(addLineItemRequest.CartId), new ProductId(addLineItemRequest.ProductId),
                addLineItemRequest.Quantity);

            var addLineItemResponse = await _mediator.Send(addLineItemCommand);

            return Ok(addLineItemResponse);
        }

        [Authorize]
        [HttpDelete("RemoveLineItemFromCart")]
        public async Task<IActionResult> RemoveLineItemFromCart([FromBody] RemoveLineItemRequest removeLineItemRequest)
        {
            var removeLineItemCommand = new RemoveLineItemCommand(new CartId(removeLineItemRequest.CartId), new LineItemId(removeLineItemRequest.LineItemId));

            var removeLineItemResponse = await _mediator.Send(removeLineItemCommand);

            return Ok(removeLineItemResponse);
        }
    }
}
