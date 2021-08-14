using MediatorWithCQRS.Application.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MediatorWithCQRS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;
        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<bool>> AddUser([FromBody] CreateUserCommand createUserCommand)
        {
            var result = await _mediator.Send(createUserCommand);
            return Ok(result);
        }
    }
}
