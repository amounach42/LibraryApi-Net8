using Dtos.Author;
using Models;

namespace Dtos.Book;

public class GetBookDetailDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public double Price { get; set; }
    public GetAuthorDto Author { get; set; }
}
