using AutoMapper;
using MediatorWithCQRS.Application.Queries;
using MediatorWithCQRS.Application.Results;
using MediatorWithCQRS.Domain.interfaces;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MediatorWithCQRS.Application.Handlers
{
    public class FindProductsHandler : IRequestHandler<FindProductsQuery, IEnumerable<FindProductQueryResult>>
    {
        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;
        public FindProductsHandler(IProductRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<FindProductQueryResult>> Handle(FindProductsQuery request, CancellationToken cancellationToken)
        {
            var products = await _repository.GetProducts();
            var result = _mapper.Map<IEnumerable<FindProductQueryResult>>(products);

            return result;
        }
    }
}
