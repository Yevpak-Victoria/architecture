using Library.Application.Interfaces;
using Library.Domain.Entities;

namespace Library.Application.Services
{
    public class UserService : IUserService
    {
        private readonly Library.Domain.Interfaces.IUserRepository _userRepo;

        public UserService(Library.Domain.Interfaces.IUserRepository userRepo)
        {
            _userRepo = userRepo;
        }

        public async Task<IEnumerable<User>> GetAllAsync()
            => await _userRepo.GetAllAsync();

        public async Task<User?> GetByIdAsync(int id)
            => await _userRepo.GetByIdAsync(id);

        public async Task<User> CreateAsync(string fullName)
        {
            var user = new User
            {
                FullName = fullName
            };

            await _userRepo.AddAsync(user);
            return user;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var user = await _userRepo.GetByIdAsync(id);
            if (user == null) return false;

            await _userRepo.DeleteAsync(id);
            return true;
        }
    }
}
