using MongoDB.Bson;
using MongoDB.Driver;

namespace Orders.DataAccess;

public class OrderRepository : IOrderRepository
{
	private readonly IMongoCollection<Order> _orderCollection;

	public OrderRepository()
	{
		var hostname = Environment.GetEnvironmentVariable("DB_HOST");
		var databaseName = Environment.GetEnvironmentVariable("DB_DATABASE");
		var connectionString = $"mongodb://{hostname}:27017";

		var client = new MongoClient(connectionString);
		var database = client.GetDatabase(databaseName);
		_orderCollection = database.GetCollection<Order>("Orders", new MongoCollectionSettings() { AssignIdOnInsert = true });
	}


	public async Task<Order> GetByIdAsync(ObjectId id)
	{
		var filter = Builders<Order>.Filter.Eq("_id", id);
		return await _orderCollection.Find(filter).FirstOrDefaultAsync();
	}

	public async Task<IEnumerable<Order>> GetAllAsync()
	{
		return await _orderCollection.Find(new BsonDocument()).ToListAsync();
	}

	public async Task AddAsync(Order entity)
	{
		await _orderCollection.InsertOneAsync(entity);
	}

	public async Task UpdateAsync(Order entity)
	{
		var filter = Builders<Order>.Filter.Eq("_id", entity.Id);
		await _orderCollection.ReplaceOneAsync(filter, entity);
	}

	public async Task DeleteAsync(ObjectId id)
	{
		var filter = Builders<Order>.Filter.Eq("_id", id);
		await _orderCollection.DeleteOneAsync(filter);
	}
}