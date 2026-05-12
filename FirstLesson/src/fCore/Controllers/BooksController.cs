using fCore.DTOs;
using fCore.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace fCore.Controllers
{
    [Route("api/boos")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpPost]
        public async Task<long> AddAsync(BookCreateDto bookCreateDto)
        {
            var id = await _bookService.AddAsync(bookCreateDto);
            return id;
        }

        [HttpGet]
        public async Task<List<BookGetDto>> GetAllAsync()
        {
            var books = await _bookService.GetAllAsync();
            return books;
        }
    }
}
