using Library.Domain.Entities;

namespace Library.Application.Interfaces
{
    public interface IBookService
    {
        Task<IEnumerable<Book>> GetAllAsync();
        Task<Book?> GetByIdAsync(int id);
        Task<Book> CreateAsync(string title, string author);
        Task<bool> DeleteAsync(int id);
    }
}
