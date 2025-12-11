using Library.Domain.Entities;

namespace Library.Domain.Interfaces
{
    public interface IReservationRepository : IRepository<Reservation>
    {
        Task<List<Reservation>> GetByUserAsync(int userId);
    }
}
