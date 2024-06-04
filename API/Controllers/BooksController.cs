using Application.Contracts;
using Application.DTOs;
using Core.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly IServiceManager _service;

        public BooksController(IServiceManager service) => _service = service;

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var books = await _service.BookService.GetBooksAsync();
                return Ok(books);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> Get(Guid id)
        {
            try
            {
                var book = await _service.BookService.GetBookByIdAsync(id);
                return Ok(book);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(BookDto model)
        {
            try
            {
                await _service.BookService.CreateBookAsync(model);
                return Created();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Put(Guid id, BookDto model)
        {
            try
            {
                await _service.BookService.UpdateBookAsync(id, model);
                return NoContent();
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                await _service.BookService.DeleteBookAsync(id);
                return NoContent();
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }

}