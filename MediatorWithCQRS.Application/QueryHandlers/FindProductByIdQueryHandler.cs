using MediatorWithCQRS.Application.Queries;
using MediatorWithCQRS.Application.QueriesResult;
using MediatorWithCQRS.Domain.interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace MediatorWithCQRS.Application.QueryHandlers
{
    public class FindProductByIdQueryHandler : IRequestHandler<FindProductByIdQuery, FindProductByIdQueryResult>
    {
        private readonly IProductRepository _repository;
        public FindProductByIdQueryHandler(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<FindProductByIdQueryResult> Handle(FindProductByIdQuery request, CancellationToken cancellationToken)
        {
            var product = await _repository.GetProductById(request.Id);

            var result = new FindProductByIdQueryResult();

            result.Id = product.Id;
            result.Name = product.Name;
            result.Amount = product.Amount;
            result.Price = product.Price;
            result.CreatedAt = product.CreatedAt;
            result.UpdatedAt = product.UpdatedAt;

            return result;
        }
    }
}
