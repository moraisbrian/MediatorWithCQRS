using MediatorWithCQRS.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MediatorWithCQRS.Domain.interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetProducts();
        Task<Product> GetProductById(int id);
        Task<bool> AddProduct(Product product);
        Task<bool> DeleteProductById(int id);
        Task<bool> UpdateProduct(Product product);
    }
}
