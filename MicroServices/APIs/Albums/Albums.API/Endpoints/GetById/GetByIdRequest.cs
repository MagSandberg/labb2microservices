using MongoDB.Bson;

namespace Albums.API.Endpoints.GetById;

public class GetByIdRequest
{
    public ObjectId Id { get; init; }
}