﻿using Domain.Common.DTOs;
using Domain.Common.Enums;
using Domain.Common.Interfaces;
using MongoDB.Bson;

namespace Albums.DataAccess.Models;

public class Album : IEntity<ObjectId>
{
    public ObjectId Id { get; init; }
    public string Title { get; init; } = string.Empty;
    public string Artist { get; init; } = string.Empty;
    public Genre Genre { get; init; }
    public IEnumerable<Track> Tracks { get; init; } = new List<Track>();
    public decimal Price { get; init; }
}