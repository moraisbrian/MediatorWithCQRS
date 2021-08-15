using MediatorWithCQRS.Application.Results;
using MediatR;

namespace MediatorWithCQRS.Application.Commands
{
    public class UpdateProductCommand : IRequest<CommandResult>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Amount { get; set; }
        public decimal Price { get; set; }

        public bool IsValid() => Id > 0 && !string.IsNullOrEmpty(Name.Trim()) && Amount >= 0 && Price > 0;
    }
}
