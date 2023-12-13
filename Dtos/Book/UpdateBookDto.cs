

namespace Dtos.Book;

public class UpdateBookDto 
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public double price { get; set; }
    public int AuthorId { get; set; }
}