using Dtos.Author;
using Models;

namespace Dtos.Book;

public class GetBookDto
{
    public string Title { get; set; }
    public string Description { get; set; }
    public double Price { get; set; }
}
