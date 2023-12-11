using Albums.DataAccess.Models;
using Domain.Common.Interfaces;
using MongoDB.Bson;

namespace Albums.DataAccess.Repositories.Interfaces;

public interface IAlbum : IGenericRepository<Album, ObjectId>
{
}