using Albums.DataAccess.Models;
using Albums.DataAccess.Repositories.Interfaces;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Albums.DataAccess.Repositories;

public class AlbumRepository : IAlbumRepository
{
    private readonly IMongoCollection<Album> _collection;

    public AlbumRepository()
    {
        var hostname = Environment.GetEnvironmentVariable("DB_HOST");
        var databaseName = Environment.GetEnvironmentVariable("DB_DATABASE");
        var connectionString = $"mongodb://{hostname}:27017";

        var client = new MongoClient(connectionString);
        var database = client.GetDatabase(databaseName);
        _collection = database.GetCollection<Album>("Albums", new MongoCollectionSettings() { AssignIdOnInsert = true });
    }

    public async Task<Album> GetByIdAsync(ObjectId id)
    {
        var filter = Builders<Album>.Filter.Eq("_id", id);
        return await _collection.Find(filter).FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<Album>> GetAllAsync()
    {
        return await _collection.Find(new BsonDocument()).ToListAsync();
    }

    public async Task AddAsync(Album entity)
    {
        await _collection.InsertOneAsync(entity);
    }

    public async Task UpdateAsync(Album entity)
    {
        throw new NotImplementedException();
    }

    public async Task DeleteAsync(ObjectId id)
    {
        throw new NotImplementedException();
    }
}