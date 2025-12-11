using Library.Domain.Entities;

namespace Library.Domain.Interfaces
{
    public interface IBookRepository : IRepository<Book>
    {
        Task<List<Book>> GetAvailableBooksAsync();
    }
}
