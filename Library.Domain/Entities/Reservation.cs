namespace Library.Domain.Entities
{
    public class Reservation
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public Book Book { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public DateTime ReservedAt { get; set; }
        public DateTime? Until { get; set; }
    }
}
