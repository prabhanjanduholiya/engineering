using MongoDB.Driver;
using mongo_db_demo.Models;

namespace mongo_db_demo.Repositories;

public class BookRepository : IBookRepository
{
    private readonly IMongoCollection<Book> _collection;

    public BookRepository(MongoDbSettings settings)
    {
        var client = new MongoClient(settings.ConnectionString);
        var db = client.GetDatabase(settings.DatabaseName);
        _collection = db.GetCollection<Book>(settings.BooksCollectionName);
    }

    public async Task<IEnumerable<Book>> GetAllAsync()
    {
        var docs = await _collection.FindAsync(_ => true);
        return await docs.ToListAsync();
    }

    public async Task<Book?> GetByIdAsync(string id)
    {
        var doc = await _collection.FindAsync(b => b.Id == id);
        return await doc.FirstOrDefaultAsync();
    }

    public async Task CreateAsync(Book book)
    {
        await _collection.InsertOneAsync(book);
    }

    public async Task UpdateAsync(string id, Book book)
    {
        await _collection.ReplaceOneAsync(b => b.Id == id, book);
    }

    public async Task DeleteAsync(string id)
    {
        await _collection.DeleteOneAsync(b => b.Id == id);
    }
}
