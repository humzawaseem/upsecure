using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace secureapis.Models
{
    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;

        public List<Product> Products { get; set; } = new List<Product>();
    }
}
