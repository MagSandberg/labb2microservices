using Domain.Common.Enums;
using Domain.Common.Interfaces;
using MongoDB.Bson;

namespace Albums.DataAccess.Models;

public class Album : IEntity<ObjectId>
{
    public ObjectId Id { get; init; }
    public string Title { get; init; }
    public string Artist { get; init; }
    public Genre Genre { get; init; }
    public IEnumerable<Track> Tracks { get; init; }
    public decimal Price { get; init; }
}