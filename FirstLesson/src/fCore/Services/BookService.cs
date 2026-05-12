using System.Linq;
using Microsoft.EntityFrameworkCore;
using fCore.Data;
using fCore.DTOs;
using fCore.Entities;

namespace fCore.Services;

public class BookService : IBookService
{

    private readonly AppDbContext _context;
    public BookService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<long> AddAsync(BookCreateDto bookCreateDto)
    {
        var book = new Book()
        {
            Name = bookCreateDto.Name,
            Price = bookCreateDto.Price,
            Author = bookCreateDto.Author
        };

        await _context.AddAsync(book);
        await _context.SaveChangesAsync();

        return book.BookId;
    }

    public async Task<List<BookGetDto>> GetAllAsync()
    {
        var books = await _context.Books.ToListAsync();
        return books.Select(b => new BookGetDto()
        {
            Author = b.Author,
            BookId = b.BookId,
            Name = b.Name,
            Price = b.Price
        }).ToList();
    }
}
