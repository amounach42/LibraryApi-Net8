using Models;
using Dtos.Author;

namespace interfaces;

public interface IAuthorRepository
{
    Task<List<Author>> GetAuthorsAsync();
    Task<Author?> GetByIdAsync(int id);
    Task<Author> CreateAsync(Author author);
	Task<Author?> UpdateByIdAsync(int id, UpdateAuthorDto authorDto);
    Task<Author?> DeleteAsync(int id);
}