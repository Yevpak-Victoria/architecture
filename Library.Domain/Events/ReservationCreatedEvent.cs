using System;

namespace Library.Domain.Events
{
    public class ReservationCreatedEvent : IDomainEvent
    {
        public int ReservationId { get; }
        public int BookId { get; }
        public int UserId { get; }
        public DateTime CreatedAt { get; }

        public ReservationCreatedEvent(int reservationId, int bookId, int userId)
        {
            ReservationId = reservationId;
            BookId = bookId;
            UserId = userId;
            CreatedAt = DateTime.UtcNow;
        }
    }
}
