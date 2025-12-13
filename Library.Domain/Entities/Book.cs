namespace Library.Domain.Entities
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public bool IsReserved { get; private set; }

        // Navigation property can be null when no reservations
        public ICollection<Reservation>? Reservations { get; set; }

        // Domain behavior: reserve and release with simple invariant checks
        public void Reserve()
        {
            if (IsReserved)
                throw new InvalidOperationException("Book is already reserved.");

            IsReserved = true;
        }

        public void Release()
        {
            if (!IsReserved)
                return;

            IsReserved = false;
        }
    }
}
