using interfaces;
using Microsoft.AspNetCore.Mvc;
using Models;
using Repositories;
using AutoMapper;
using Dtos.Author;
using library.Migrations;

namespace Controllers;

[Route("api/[Controller]")]
[ApiController]
public class AuthorController : ControllerBase {
    private readonly IMapper _mapper;
    private readonly IAuthorRepository _authorRepository;
    public AuthorController (IMapper mapper, IAuthorRepository authorRepository)
    {
        _mapper = mapper;
        _authorRepository = authorRepository;
    }

    [HttpGet]
    [Route("get-all")]
    public async Task<ActionResult<List<GetAuthorDto>>> GetAllAsync()
    {
        var authors = await _authorRepository.GetAuthorsAsync();
        var records = _mapper.Map<List<GetAuthorDto>>(authors);
        return Ok(records);
    }

    [HttpGet]
    [Route("get-by-id")]
    public async Task<ActionResult<GetAuthorDetailDto>> GetByIdAsync([FromQuery] int id)
    {
        var AuthorToGet = await _authorRepository.GetByIdAsync(id);
        if (AuthorToGet == null)
            return NotFound("Author Does Not Found!");
        var record = _mapper.Map<GetAuthorDetailDto>(AuthorToGet);
        return Ok(record);
    }

    [HttpPost]
    [Route("create")]
    public async Task<ActionResult<CreateAuthorDto>> CreateAsync([FromBody] CreateAuthorDto authorDto)
    {
        var author = _mapper.Map<Author>(authorDto);
        var createdAuthor = await _authorRepository.CreateAsync(author);
        return Ok(_mapper.Map<CreateAuthorDto>(createdAuthor));
    }

    [HttpPut]
    [Route("update")]
    public async Task<ActionResult<UpdateAuthorDto>> UpdateAsync([FromQuery] int id,
         [FromBody] UpdateAuthorDto authorDto)
    {
        var authorToUpdate = await _authorRepository.GetByIdAsync(id);
        if (authorToUpdate == null)
            return NotFound("Author Does Not Found!");
        var updatedAuthor = await _authorRepository.UpdateByIdAsync(id, authorDto);
        return Ok(_mapper.Map<UpdateAuthorDto>(updatedAuthor));
    }

    [HttpDelete]
    [Route("delete")]
    public async Task<ActionResult<Author>> DeleteAsync([FromQuery] int id)
    {
        var authorToDelete = await _authorRepository.GetByIdAsync(id);
        if (authorToDelete == null)
            return NotFound("Author Does Not Exist!");
        var deleteAuthor = await _authorRepository.DeleteAsync(id);
        return Ok(deleteAuthor);
    }

}