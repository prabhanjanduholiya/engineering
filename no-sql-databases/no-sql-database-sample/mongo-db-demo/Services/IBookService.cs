using mongo_db_demo.Models;

namespace mongo_db_demo.Services;

public interface IBookService
{
    Task<IEnumerable<Book>> GetAllAsync();
    Task<Book?> GetByIdAsync(string id);
    Task CreateAsync(Book book);
    Task UpdateAsync(string id, Book book);
    Task DeleteAsync(string id);
}
