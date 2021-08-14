using MediatorWithCQRS.Application.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MediatorWithCQRS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public IActionResult GetTest()
        {
            return Ok();
        }

        [HttpPost]
        public async Task<ActionResult<bool>> AddProduct([FromBody] CreateProductCommand productRequest)
        {
            var result = await _mediator.Send(productRequest);
            return Ok(result);
        }
    }
}
