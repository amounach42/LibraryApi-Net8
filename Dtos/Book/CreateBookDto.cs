
namespace Dtos.Book;

public class CreateBookDto 
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public int AuthorId { get; set; }
}