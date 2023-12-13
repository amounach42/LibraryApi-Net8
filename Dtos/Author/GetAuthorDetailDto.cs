using Dtos.Book;

namespace Dtos.Author;

public class GetAuthorDetailDto 
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime BirthDay { get; set; }
    public ICollection<GetBookDto> Books { get; set; }
}