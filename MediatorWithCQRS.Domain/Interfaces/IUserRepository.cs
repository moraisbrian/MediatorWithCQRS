using MediatorWithCQRS.Domain.Entities;
using System.Threading.Tasks;

namespace MediatorWithCQRS.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task<bool> AddUser(User user);
    }
}
