using System;

namespace MediatorWithCQRS.Application.QueriesResult
{
    public class FindProductByIdQueryResult
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Amount { get; set; }
        public decimal Price { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
