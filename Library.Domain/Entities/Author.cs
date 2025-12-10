using Library.Domain.Entities;

namespace Library.Domain.Models
{
    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public ICollection<Book>? Books { get; set; }
    }
}
