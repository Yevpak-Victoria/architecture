using Library.Domain.Entities;

namespace Library.Application.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetAllAsync();
        Task<User?> GetByIdAsync(int id);
        Task<User> CreateAsync(string fullName);
        Task<bool> DeleteAsync(int id);
    }
}
