using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CisReg_Website.Models;

public class Address
{
  public string? City { get; set; }
  public string? Zipcode { get; set; }
  public string? StateName { get; set; }
  public string? StreetName { get; set; }
  public string? Number { get; set; }
  public string? Neighborhood { get; set; }
}

public class HallModel
{
  [BsonId]
  public ObjectId Id { get; set; }

  [BsonElement("cnpj")]
  public string? CNPJ { get; set; }

  [BsonElement("cnes")]
  public int CNES { get; set; }

  [BsonElement("agreement")]
  public int Agreement { get; set; }

  [BsonElement("address")]
  public Address? Address { get; set; }
}