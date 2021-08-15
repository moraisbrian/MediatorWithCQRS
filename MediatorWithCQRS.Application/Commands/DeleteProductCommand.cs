using MediatorWithCQRS.Application.Results;
using MediatR;

namespace MediatorWithCQRS.Application.Commands
{
    public class DeleteProductCommand : IRequest<CommandResult>
    {
        public int Id { get; set; }
    }
}
