using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace CisReg_Website.Models;

public class UserModel
{
  [BsonId]
  public ObjectId Id { get; set; }

    [BsonElement("first_name")]
    [Display(Name = "Nome")]
    public string? FirstName { get; set; }

  [BsonElement("email")]
  public string? Email { get; set; }
  
    [BsonElement("last_name")]
    [Display(Name = "Sobrenome")]
    public string? LastName { get; set; }

  [BsonElement("password")]
    [Display(Name = "Senha")]
    public string? Password { get; set; }

}