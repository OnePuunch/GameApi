using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace GameApi.Models
{
    [DataContract]
    [BsonIgnoreExtraElements]
    public class Player
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [DefaultValue("")]
        public string Id { get; set; } = String.Empty;

        [BsonElement("name")]
        [DefaultValue("")]
        public string Name { get; set; } = String.Empty;

        [BsonElement("level")]
        [DefaultValue(1)]
        public int Level { get; set; }
    }
}
