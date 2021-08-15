using MediatorWithCQRS.Domain.Entities;
using MediatorWithCQRS.Domain.interfaces;
using MediatorWithCQRS.Application.Commands;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using MediatorWithCQRS.Application.Results;
using System;
using AutoMapper;

namespace MediatorWithCQRS.Application.Handlers
{
    public class CreateProductHandler : IRequestHandler<CreateProductCommand, CommandResult>
    {
        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;
        public CreateProductHandler(IProductRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<CommandResult> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var product = _mapper.Map<Product>(request);
                var result = await _repository.AddProduct(product);

                if (result)
                    return new CommandResult { Success = true, Message = "Produto adicionado com sucesso" };
                else
                    return new CommandResult { Success = false, Message = "Erro ao adicionar produto" };
            }
            catch (Exception ex)
            {
                return new CommandResult { Success = false, Message = $"Erro ao adicionar produto: {ex.Message}" };
            }
        }
    }
}
