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

    [BsonElement("adminPassword")]
    public string? AdminPassword { get; set; }

    [BsonElement("cep")]
    public string? Cep { get; set; }

    [BsonElement("position")]
    public string? Position { get; set; }

    [BsonElement("cpf")]
    public string? Cpf { get; set; }

    [BsonElement("userId")]
    public string? UserId { get; set; }

    [BsonElement("workHours")]
    public string? WorkHours { get; set; }

    [BsonElement("admissionDate")]
    public DateTime AdmissionDate { get; set; }

    [BsonElement("birthDate")]
    public DateTime BirthDate { get; set; }
}