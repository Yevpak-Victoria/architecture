using Library.Application.Interfaces;
using Library.Domain.Entities;

namespace Library.Application.Services
{
    public class ReservationService : IReservationService
    {
        private readonly Library.Domain.Interfaces.IReservationRepository _reservationRepo;
        private readonly Library.Domain.Interfaces.IBookRepository _bookRepo;
        private readonly Library.Domain.Interfaces.IUserRepository _userRepo;

        public ReservationService(
            Library.Domain.Interfaces.IReservationRepository reservationRepo,
            Library.Domain.Interfaces.IBookRepository bookRepo,
            Library.Domain.Interfaces.IUserRepository userRepo)
        {
            _reservationRepo = reservationRepo;
            _bookRepo = bookRepo;
            _userRepo = userRepo;
        }

        public async Task<IEnumerable<Reservation>> GetAllAsync()
            => await _reservationRepo.GetAllAsync();

        public async Task<Reservation?> GetByIdAsync(int id)
            => await _reservationRepo.GetByIdAsync(id);

        public async Task<Reservation> CreateAsync(int bookId, int userId, DateTime until)
        {
            var book = await _bookRepo.GetByIdAsync(bookId);
            var user = await _userRepo.GetByIdAsync(userId);

            if (book == null) throw new Exception("Book not found");
            if (user == null) throw new Exception("User not found");

            if (book.IsReserved) throw new Exception("Book is already reserved");

            // mark book as reserved using domain behavior
            book.Reserve();
            await _bookRepo.UpdateAsync(book);

            var reservation = new Reservation
            {
                BookId = bookId,
                UserId = userId,
                ReservedAt = DateTime.UtcNow,
                Until = until
            };

            await _reservationRepo.AddAsync(reservation);
            return reservation;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var reservation = await _reservationRepo.GetByIdAsync(id);
            if (reservation == null) return false;

            // Try to release the book when deleting reservation
            var book = await _bookRepo.GetByIdAsync(reservation.BookId);
            if (book != null)
            {
                book.Release();
                await _bookRepo.UpdateAsync(book);
            }

            await _reservationRepo.DeleteAsync(id);
            return true;
        }
    }
}
