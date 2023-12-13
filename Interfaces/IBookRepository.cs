using Models;

namespace library.Interfaces;

public interface IBookRepository {
    Task<List<Book>> GetBooksAsync();
    Task<Book?> GetBookByIdAsync(int id);
    Task<Book> CreateBookAsync(Book book);
    Task<Book?> UpdateBookByIdAsync(int id, Book book);
    Task<Book?> DeleteBookByIdAsync(int id);
}