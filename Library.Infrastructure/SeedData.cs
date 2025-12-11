using Library.Domain.Entities;
using Library.Infrastructure.Data;

public static class SeedData
{
    public static void Initialize(LibraryDbContext context)
    {
        if (!context.Books.Any())
        {
            context.Books.AddRange(
                new Book { Title = "Harry Potter", Author = "J. K. Rowling" },
                new Book { Title = "Clean Code", Author = "Robert C. Martin" }
            );
        }

        if (!context.Users.Any())
        {
            context.Users.AddRange(
                new User { FullName = "Alice Johnson" },
                new User { FullName = "Bob Smith" }
            );
        }

        context.SaveChanges();
    }
}
