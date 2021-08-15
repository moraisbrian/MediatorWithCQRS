using MediatorWithCQRS.Application.Results;
using MediatR;

namespace MediatorWithCQRS.Application.Commands
{
    public class CreateProductCommand : IRequest<CommandResult>
    {
        public string Name { get; set; }
        public int Amount { get; set; }
        public decimal Price { get; set; }

        public bool IsValid() => !string.IsNullOrEmpty(Name.Trim()) && Amount > 0 && Price > 0;
    }
}
