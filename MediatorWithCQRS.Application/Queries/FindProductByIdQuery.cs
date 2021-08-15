using MediatorWithCQRS.Application.QueriesResult;
using MediatR;

namespace MediatorWithCQRS.Application.Queries
{
    public class FindProductByIdQuery : IRequest<FindProductByIdQueryResult>
    {
        public int Id { get; set; }
    }
}
