namespace Library.Domain.Entities
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public bool IsReserved { get; set; }

        public ICollection<Reservation>? Reservations { get; set; }
    }
}
