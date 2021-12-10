﻿using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace JordansPizza.Models
{
    public abstract class BaseResource
    {
        [BsonId]
        public string Id { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public int Version { get; set; } = 1;

        [JsonIgnore]
        public bool Deleted { get; set; }
    }
}
