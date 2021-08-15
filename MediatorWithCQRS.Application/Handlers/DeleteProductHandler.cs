using MediatorWithCQRS.Application.Commands;
using MediatorWithCQRS.Application.Results;
using MediatorWithCQRS.Domain.interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MediatorWithCQRS.Application.Handlers
{
    public class DeleteProductHandler : IRequestHandler<DeleteProductCommand, CommandResult>
    {
        private readonly IProductRepository _repository;
        public DeleteProductHandler(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<CommandResult> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _repository.DeleteProductById(request.Id);

                if (result)
                    return new CommandResult { Success = true, Message = "Produto deletado com sucesso" };
                else
                    return new CommandResult { Success = false, Message = "Erro ao deletar produto" };
            }
            catch (Exception ex)
            {
                return new CommandResult { Success = false, Message = $"Erro ao deletar produto: {ex.Message}" };
            }
        }
    }
}
