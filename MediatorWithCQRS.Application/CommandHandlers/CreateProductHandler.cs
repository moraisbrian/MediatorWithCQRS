﻿using MediatorWithCQRS.Domain.Entities;
using MediatorWithCQRS.Domain.interfaces;
using MediatorWithCQRS.Application.Commands;
using MediatorWithCQRS.Application.CommandsResult;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace MediatorWithCQRS.Application.CommandHandlers
{
    public class CreateProductHandler : IRequestHandler<CreateProductCommand, CommandResult>
    {
        private readonly IProductRepository _repository;
        public CreateProductHandler(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<CommandResult> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = new Product();
            product.Name = request.Name;
            product.Amount = request.Amount;
            product.Price = request.Price;

            var result = await _repository.AddProduct(product);

            if (result)
                return new CommandResult { Success = true, Message = "Produto adicionado com sucesso" };
            else
                return new CommandResult { Success = false, Message = "Erro ao adicionar produto" };
        }
    }
}
