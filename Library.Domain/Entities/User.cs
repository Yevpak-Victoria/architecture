namespace Library.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public ICollection<Reservation> Reservations { get; set; }
    }
}
