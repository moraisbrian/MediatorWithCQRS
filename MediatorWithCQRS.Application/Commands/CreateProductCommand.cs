using MediatorWithCQRS.Application.CommandsResult;
using MediatR;

namespace MediatorWithCQRS.Application.Commands
{
    public class CreateProductCommand : IRequest<CommandResult>
    {
        public string Name { get; set; }
        public int Amount { get; set; }
        public decimal Price { get; set; }
    }
}
