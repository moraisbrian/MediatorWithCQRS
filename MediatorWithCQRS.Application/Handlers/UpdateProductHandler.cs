using AutoMapper;
using MediatorWithCQRS.Application.Commands;
using MediatorWithCQRS.Application.Results;
using MediatorWithCQRS.Domain.Entities;
using MediatorWithCQRS.Domain.interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MediatorWithCQRS.Application.Handlers
{
    public class UpdateProductHandler : IRequestHandler<UpdateProductCommand, CommandResult>
    {
        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;
        public UpdateProductHandler(IProductRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<CommandResult> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var product = _mapper.Map<Product>(request);
                var result = await _repository.UpdateProduct(product);

                if (result)
                    return new CommandResult { Success = true, Message = "Produto atualizado com sucesso" };
                else
                    return new CommandResult { Success = false, Message = "Erro ao atualizar produto" };
            }
            catch (Exception ex)
            {
                return new CommandResult { Success = false, Message = $"Erro ao atualizar produto: {ex.Message}" };
            }
        }
    }
}

