using AutoMapper;
using MediatorWithCQRS.Application.Queries;
using MediatorWithCQRS.Application.Results;
using MediatorWithCQRS.Domain.interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace MediatorWithCQRS.Application.Handlers
{
    public class FindProductByIdHandler : IRequestHandler<FindProductByIdQuery, FindProductQueryResult>
    {
        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;
        public FindProductByIdHandler(IProductRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<FindProductQueryResult> Handle(FindProductByIdQuery request, CancellationToken cancellationToken)
        {
            var product = await _repository.GetProductById(request.Id);
            var result = _mapper.Map<FindProductQueryResult>(product);

            return result;
        }
    }
}
