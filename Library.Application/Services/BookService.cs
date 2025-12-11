using Library.Application.Interfaces;
using Library.Domain.Entities;

namespace Library.Application.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepo;

        public BookService(IBookRepository bookRepo)
        {
            _bookRepo = bookRepo;
        }

        public async Task<IEnumerable<Book>> GetAllAsync()
            => await _bookRepo.GetAllAsync();

        public async Task<Book?> GetByIdAsync(int id)
            => await _bookRepo.GetByIdAsync(id);

        public async Task<Book> CreateAsync(string title, string author)
        {
            var book = new Book
            {
                Title = title,
                Author = author,
                IsReserved = false
            };

            await _bookRepo.AddAsync(book);
            return book;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var book = await _bookRepo.GetByIdAsync(id);
            if (book == null) return false;

            await _bookRepo.DeleteAsync(id);
            return true;
        }
    }
}
