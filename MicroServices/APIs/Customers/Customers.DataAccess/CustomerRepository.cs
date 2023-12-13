using MongoDB.Bson;
using MongoDB.Driver;

namespace Customers.DataAccess;

public class CustomerRepository : ICustomerRepository
{
    private readonly IMongoCollection<Customer> _collection;

    public CustomerRepository()
    {
        var hostname = Environment.GetEnvironmentVariable("DB_HOST");
        var databaseName = Environment.GetEnvironmentVariable("DB_DATABASE");
        var connectionString = $"mongodb://{hostname}:27017";

        var client = new MongoClient(connectionString);
        var database = client.GetDatabase(databaseName);
        _collection = database.GetCollection<Customer>("Customers", new MongoCollectionSettings() { AssignIdOnInsert = true });
    }
    public async Task<Customer> GetByIdAsync(ObjectId id)
    {
        var filter = Builders<Customer>.Filter.Eq("_id", id);
        return await _collection.Find(filter).FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<Customer>> GetAllAsync()
    {
        return await _collection.Find(new BsonDocument()).ToListAsync();
    }

    public async Task AddAsync(Customer entity)
    {
        await _collection.InsertOneAsync(entity);
    }

    public async Task UpdateAsync(Customer entity)
    {
        var filter = Builders<Customer>.Filter.Eq("_id", entity.Id);
        await _collection.ReplaceOneAsync(filter, entity);
    }

    public async Task DeleteAsync(ObjectId id)
    {
        var filter = Builders<Customer>.Filter.Eq("_id", id);
        await _collection.DeleteOneAsync(filter);
    }
}