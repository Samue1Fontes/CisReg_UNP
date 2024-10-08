using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CisReg_Website.Models;

public class UserModel
{
  [BsonId]
  public ObjectId Id { get; set; }

  [BsonElement("name")]
  public string? Name { get; set; }

  [BsonElement("email")]
  public string? Email { get; set; }
}