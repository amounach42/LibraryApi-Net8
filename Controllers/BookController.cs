using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;
using Data;
using library.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Dtos.Book;
using AutoMapper;

[Route("Api/[Controller]")]
[ApiController]
public class BookController  : ControllerBase
{
    private readonly IBookRepository _bookRepository;
    private readonly IMapper _mapper;
    public BookController(IMapper mapper, IBookRepository bookRepository)
    {
        _mapper = mapper;
        _bookRepository = bookRepository;
    }

    [HttpGet]
    [Route("get-all")]
    public async Task<ActionResult<List<GetBookDto>>> GetBooksAsync()
    {
        var books = await _bookRepository.GetBooksAsync();
        var records = _mapper.Map<List<GetBookDto>>(books);
        return Ok(records);
    }

    [HttpGet]
    [Route("get-by-id")]
    public async Task<ActionResult<Book>> GetByIdAsync([FromQuery] int id)
    {
        var book = await _bookRepository.GetBookByIdAsync(id);
        if (book == null)
            return NotFound("Book does not Exist");
        var record = _mapper.Map<GetBookDto>(book);
        return Ok(record);
    }
    [HttpPost]
    [Route("create-book")]
    public async Task<ActionResult<Book>> CreateBook([FromBody]CreateBookDto bookDto)
    {
        var book = _mapper.Map<Book>(bookDto);

        var createdBook = await _bookRepository.CreateBookAsync(book);
        var record = _mapper.Map<CreateBookDto>(createdBook);
        return Ok(record);
    }

    [HttpPut]
    [Route("update-book-by-id")]
    public async Task<ActionResult<Book>> UpdateBookAsync([FromQuery]int id,[FromBody] UpdateBookDto bookDto)
    {
        var book = _mapper.Map<Book>(bookDto);

        var bookToUpdate = _bookRepository.GetBookByIdAsync(id);
        if (bookToUpdate == null)
            return NotFound("Book Does not exist");
        else
        {
            var updatedBook = await _bookRepository.UpdateBookByIdAsync(id, book);
            var record = _mapper.Map<UpdateBookDto>(updatedBook);
            return Ok(record);
        }
    }

    [HttpDelete]
    [Route("delete-book-by-id")]
    public async Task<ActionResult<Book>> DeleteBookAsync([FromQuery] int id) {
        var bookToDelete = await _bookRepository.GetBookByIdAsync(id);
        if (bookToDelete == null)
            return NotFound("Book Does not exist");
        else
        {
            var deletedBook = await _bookRepository.DeleteBookByIdAsync(id);
            return Ok(deletedBook);
        }
    }

}