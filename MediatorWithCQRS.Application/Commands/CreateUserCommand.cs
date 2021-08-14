using MediatorWithCQRS.Application.CommandsResult;
using MediatR;

namespace MediatorWithCQRS.Application.Commands
{
    public class CreateUserCommand : IRequest<DefaultCommandResult>
    {
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
