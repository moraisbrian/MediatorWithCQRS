using Dapper;
using MediatorWithCQRS.Domain.Entities;
using MediatorWithCQRS.Domain.Interfaces;
using Microsoft.Extensions.Configuration;
using Npgsql;
using System.Threading.Tasks;

namespace MediatorWithCQRS.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly string _connectionString;
        public UserRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("WriteDB");
        }

        public async Task<bool> AddUser(User user)
        {
            using (var conn = new NpgsqlConnection(_connectionString))
            {
                conn.Open();

                var result = await conn.ExecuteAsync("INSERT INTO \"User\"(\"Name\", \"Email\") VALUES(@Name, @Email)",
                    new { Name = user.Name, Email = user.Email });

                if (result == 1)
                    return true;
            }

            return false;
        }
    }
}
