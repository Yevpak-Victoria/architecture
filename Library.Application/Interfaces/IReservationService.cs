using Library.Domain.Entities;

namespace Library.Application.Interfaces
{
    public interface IReservationService
    {
        Task<IEnumerable<Reservation>> GetAllAsync();
        Task<Reservation?> GetByIdAsync(int id);
        Task<Reservation> CreateAsync(int bookId, int userId, DateTime until);
        Task<bool> DeleteAsync(int id);
    }
}
