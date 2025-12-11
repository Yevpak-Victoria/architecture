namespace Library.Application.DTOs
{
    public class ReservationDto
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public int UserId { get; set; }
        public DateTime ReservedAt { get; set; }
        public DateTime? Until { get; set; }
    }
}
