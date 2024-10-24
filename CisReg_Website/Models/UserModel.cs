using CisReg_Website.Data;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CisReg_Website.Models;

public class UserModel : DataFoundation
{

  [BsonElement("name")]
  public string? Name { get; set; }

  [BsonElement("email")]
  public string? Email { get; set; }
}