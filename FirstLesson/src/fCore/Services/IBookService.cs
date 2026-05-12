using fCore.DTOs;
namespace fCore.Services;

public interface IBookService
{
    Task<long> AddAsync(BookCreateDto bookCreateDto);
    Task<List<BookGetDto>> GetAllAsync();
}