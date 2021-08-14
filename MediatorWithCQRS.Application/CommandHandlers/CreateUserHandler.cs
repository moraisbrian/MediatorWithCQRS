using MediatorWithCQRS.Domain.Entities;
using MediatorWithCQRS.Domain.Interfaces;
using MediatorWithCQRS.Application.Commands;
using MediatorWithCQRS.Application.CommandsResult;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MediatorWithCQRS.Application.CommandHandlers
{
    public class CreateUserHandler : IRequestHandler<CreateUserCommand, DefaultCommandResult>
    {
        private readonly IUserRepository _repository;
        public CreateUserHandler(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<DefaultCommandResult> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = new User();
            user.Name = request.Name;
            user.Email = request.Email;

            var result = await _repository.AddUser(user);

            if (result)
                return new DefaultCommandResult { Success = true, Message = "Usuário adicionado com sucesso" };
            else
                return new DefaultCommandResult { Success = false, Message = "Erro ao adicionar usuário" };
        }
    }
}
