using MediatorWithCQRS.Application.Commands;
using MediatorWithCQRS.Application.Queries;
using MediatorWithCQRS.Application.QueriesResult;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MediatorWithCQRS.Api.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<FindProductByIdQueryResult>> GetTest(int id)
        {
            var query = new FindProductByIdQuery();
            query.Id = id;
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<bool>> AddProduct([FromBody] CreateProductCommand productRequest)
        {
            var result = await _mediator.Send(productRequest);
            return Ok(result);
        }
    }
}
