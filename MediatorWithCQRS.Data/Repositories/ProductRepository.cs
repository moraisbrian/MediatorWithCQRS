using MediatorWithCQRS.Domain.Entities;
using MediatorWithCQRS.Domain.interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Dapper;
using Npgsql;
using Microsoft.Extensions.Configuration;

namespace MediatorWithCQRS.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly string _connStrWriteDb;
        private readonly string _connStrReadDb;
        public ProductRepository(IConfiguration configuration)
        {
            _connStrWriteDb = configuration.GetConnectionString("WriteDB");
            _connStrReadDb = configuration.GetConnectionString("ReadDB");
        }

        public async Task<bool> AddProduct(Product product)
        {
            using (var conn = new NpgsqlConnection(_connStrWriteDb))
            {
                conn.Open();

                var createdAt = DateTime.Now;

                var result = await conn.ExecuteAsync(
                    "INSERT INTO \"Product\"(\"Name\", \"Amount\", \"Price\", \"CreatedAt\", \"UpdatedAt\") VALUES(@Name, @Amount, @Price, @CreatedAt, @UpdatedAt)", 
                    new 
                    { 
                        Name = product.Name,
                        Amount = product.Amount,
                        Price = product.Price,
                        CreatedAt = createdAt,
                        UpdatedAt = createdAt
                    }
                );

                if (result == 1)
                    return true;
            }

            return false;
        }

        public async Task<bool> DeleteProductById(int id)
        {
            using (var conn = new NpgsqlConnection(_connStrWriteDb))
            {
                conn.Open();

                var result = await conn.ExecuteAsync(
                    "DELETE FROM \"Product\" WHERE \"Id\" = @Id",
                    new { Id = id}
                );

                if (result == 1)
                    return true;
            }

            return false;
        }

        public async Task<Product> GetProductById(int id)
        {
            using (var conn = new NpgsqlConnection(_connStrWriteDb))
            {
                conn.Open();

                var product = await conn.QueryFirstAsync<Product>(
                    "SELECT * FROM \"Product\" WHERE \"Id\" = @Id",
                    new { Id = id }
                );

                return product;
            }
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            using (var conn = new NpgsqlConnection(_connStrWriteDb))
            {
                conn.Open();

                var product = await conn.QueryAsync<Product>("SELECT * FROM \"Product\"");

                return product;
            }
        }

        public async Task<bool> UpdateProduct(Product product)
        {
            using (var conn = new NpgsqlConnection(_connStrWriteDb))
            {
                conn.Open();

                var result = await conn.ExecuteAsync(
                    @"UPDATE ""Product"" 
                    SET ""Name"" = @Name,
                    ""Amount"" = @Amount,
                    ""Price"" = @Price,
                    ""UpdatedAt"" = @UpdatedAt
                    WHERE ""Id"" = @Id",
                    new
                    {
                        Id = product.Id,
                        Name = product.Name,
                        Amount = product.Amount,
                        Price = product.Price,
                        UpdatedAt = DateTime.Now
                    }
                );

                if (result == 1)
                    return true;
            }

            return false;
        }
    }
}
