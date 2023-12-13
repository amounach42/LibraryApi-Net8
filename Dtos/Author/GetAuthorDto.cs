using Dtos.Book;

namespace Dtos.Author;

public class GetAuthorDto 
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public ICollection<GetBookDto> Books { get; set; }
}