using AutoMapper;
using Data;
using Dtos.Author;
using interfaces;
using Microsoft.EntityFrameworkCore;
using Models;

namespace Repositories;

public class AuthorRepository : IAuthorRepository
{
    private readonly AppDbContext _dbContext;
    private readonly IMapper _mapper;
	public AuthorRepository(IMapper mapper, AppDbContext appDbContext)
	{
		_mapper = mapper;
		_dbContext = appDbContext;
	}
    public async Task<List<Author>> GetAuthorsAsync()
    {
        var authors = await _dbContext.Authors.Include(author => 
			author.Books).ToListAsync();
        return authors;
    }
    public async Task<Author?> GetByIdAsync(int id)
    {
       var author = await _dbContext.Authors.Include(author => author.Books)
	   	.FirstOrDefaultAsync(a => a.Id == id);
	   return author;
    }
	public async Task<Author> CreateAsync(Author author)
	{
		await _dbContext.Authors.AddAsync(author);
		await _dbContext.SaveChangesAsync();
		return author;		
	}
	public async Task<Author?> UpdateByIdAsync(int id, UpdateAuthorDto authorDto)
	{
		var authorToUpdate = await _dbContext.Authors.FirstOrDefaultAsync(a => a.Id == id);
		if (authorToUpdate == null)
			return null;
		var author = _mapper.Map(authorDto, authorToUpdate);
		_dbContext.Update(author);
		await _dbContext.SaveChangesAsync();
		return  author;
	}
	public async Task<Author?> DeleteAsync(int id)
	{
		var authorToDelete = await _dbContext.Authors.FindAsync(id);
		if (authorToDelete == null)
			return null;
		_dbContext.Remove(authorToDelete);
		await _dbContext.SaveChangesAsync();
		return authorToDelete;
	}

}