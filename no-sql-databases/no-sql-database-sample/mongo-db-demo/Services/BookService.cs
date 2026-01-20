using mongo_db_demo.Models;
using mongo_db_demo.Repositories;

namespace mongo_db_demo.Services;

public class BookService : IBookService
{
    private readonly IBookRepository _repository;

    public BookService(IBookRepository repository)
    {
        _repository = repository;
    }

    public Task<IEnumerable<Book>> GetAllAsync() => _repository.GetAllAsync();

    public Task<Book?> GetByIdAsync(string id) => _repository.GetByIdAsync(id);

    public Task CreateAsync(Book book) => _repository.CreateAsync(book);

    public Task UpdateAsync(string id, Book book) => _repository.UpdateAsync(id, book);

    public Task DeleteAsync(string id) => _repository.DeleteAsync(id);
}
