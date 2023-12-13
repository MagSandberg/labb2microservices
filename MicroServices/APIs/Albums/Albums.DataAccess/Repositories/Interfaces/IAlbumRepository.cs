using Albums.DataAccess.Models;
using Domain.Common.Interfaces;
using MongoDB.Bson;

namespace Albums.DataAccess.Repositories.Interfaces;

public interface IAlbumRepository : IGenericRepository<Album, ObjectId>
{
    Task<Album> GetByIdAsync(ObjectId id);
    Task<IEnumerable<Album>> GetAllAsync();
    Task AddAsync(Album entity);
}