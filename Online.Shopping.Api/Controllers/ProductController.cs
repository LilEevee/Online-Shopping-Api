using MediatR;
using Microsoft.AspNetCore.Mvc;
using Online.Shopping.Api.Requests.Product;
using Online.Shopping.Application.Products.Create;
using Online.Shopping.Application.Products.Delete;
using Online.Shopping.Application.Products.Get;
using Online.Shopping.Application.Products.Update;
using Online.Shopping.Domain.Products;

// TODO : FIX ERROR HANDLING

namespace Online.Shopping.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<WeatherForecastController> _logger;

        public ProductController(ILogger<WeatherForecastController> logger, IMediator mediator)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Get(int id)
        {
            var getProductQueryById = new GetProductQueryById(new ProductId(id));

            await _mediator.Send(getProductQueryById);

            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> Get(string name, int page, int pageSize)
        {
            var getProductQueryById = new GetProductsQuery(name, page, pageSize);

            await _mediator.Send(getProductQueryById);

            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateProductRequest createProductRequest)
        {
            var createProductCommmand = new CreateProductCommand(new ProductId(createProductRequest.ProductId),
                createProductRequest.Name, createProductRequest.Price, createProductRequest.Sku);

            await _mediator.Send(createProductCommmand);

            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] UpdateProductRequest updateProductRequest)
        {
            var updateProductCommand = new UpdateProductCommand(new ProductId(updateProductRequest.ProductId),
                updateProductRequest.Name, updateProductRequest.Price, updateProductRequest.Sku);
            
                await _mediator.Send(updateProductRequest);

            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var deleteCommand = new DeleteProductCommand(new ProductId(id));

            await _mediator.Send(deleteCommand);

            return Ok();
        }
    }
}
