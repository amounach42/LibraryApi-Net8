using Data;
using Models;
using Dtos.Book;
using Dtos.Author;
using AutoMapper;

namespace library.Configuration;
public class AutomapperConfig : Profile
{
    public AutomapperConfig()
    {
        CreateMap<Book, GetBookDto>().ReverseMap();
        CreateMap<Book, GetBookDetailDto>().ReverseMap();
        CreateMap<Book, CreateBookDto>().ReverseMap();
        CreateMap<Book, UpdateBookDto>().ReverseMap();
        
        CreateMap<Author, GetAuthorDto>().ReverseMap();
        CreateMap<Author, GetAuthorDetailDto>().ReverseMap();
        CreateMap<Author, CreateAuthorDto>().ReverseMap();
        CreateMap<Author, UpdateAuthorDto>().ReverseMap();
    }
}