namespace Library.Application.DTOs
{
    public class CreateReservationDto
    {
        public int BookId { get; set; }
        public int UserId { get; set; }
        public DateTime? Until { get; set; }
    }
}
