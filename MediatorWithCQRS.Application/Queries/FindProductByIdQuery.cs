using MediatorWithCQRS.Application.Results;
using MediatR;

namespace MediatorWithCQRS.Application.Queries
{
    public class FindProductByIdQuery : IRequest<FindProductQueryResult>
    {
        public int Id { get; set; }
    }
}
