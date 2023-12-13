using System.Security.Cryptography.X509Certificates;
using AutoMapper;
using Data;
using library.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;

namespace Repositories;
public class BookRepository : IBookRepository
{
    private readonly AppDbContext _dbContext;
    private readonly IMapper _mapper;
    public BookRepository(IMapper mapper, AppDbContext dbContext)
    {
        _mapper = mapper;
        _dbContext = dbContext;
    }

    public async Task<List<Book>> GetBooksAsync()
    {
        return await _dbContext.Books.Include(book => book.Author).ToListAsync();
    }
    public async Task<Book?> GetBookByIdAsync(int id)
    {
        var book = await _dbContext.Books.Include(book => book.Author).FirstOrDefaultAsync(b => b.Id == id);
        return book;
    }
    public async Task<Book> CreateBookAsync(Book book)
    {
        await _dbContext.Books.AddAsync(book);
        await _dbContext.SaveChangesAsync();
        return book;
    }
    public async Task<Book?> UpdateBookByIdAsync(int id, Book book)
    {
        var UpdatedBook = await _dbContext.Books.FindAsync(id);
        if (UpdatedBook == null)
            return null;
        UpdatedBook.Id = book.Id;
        UpdatedBook.Title = book.Title;
        UpdatedBook.Description = book.Description;
        UpdatedBook.Price = book.Price;
        _dbContext.Books.Update(UpdatedBook);
        await _dbContext.SaveChangesAsync();
        return UpdatedBook;
    }
    public async Task<Book?> DeleteBookByIdAsync(int id) {
        var book = await _dbContext.Books.FindAsync(id);
        if (book == null)
            return null;
        _dbContext.Books.Remove(book);
        await _dbContext.SaveChangesAsync();
        return book;
    }
}
