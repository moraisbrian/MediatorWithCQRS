using MediatorWithCQRS.Application.Results;
using MediatR;
using System.Collections.Generic;

namespace MediatorWithCQRS.Application.Queries
{
    public class FindProductsQuery : IRequest<IEnumerable<FindProductQueryResult>>
    {
    }
}
