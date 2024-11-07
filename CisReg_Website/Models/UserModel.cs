using Microsoft.Build.Framework;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace CisReg_Website.Models;

public class UserModel
{
  [BsonId]
  public ObjectId Id { get; set; }

    [BsonElement("FirstName")]
    [Display(Name = "Nome")]
    public string? FirstName { get; set; }

  [BsonElement("Email")]
    [Display(Name = "Email")]
    [System.ComponentModel.DataAnnotations.Required(ErrorMessage ="Campo Email é obrigatório")]
    [EmailAddress(ErrorMessage = "O campo email deve ter email válido")]
    public string? Email { get; set; }
  
    [BsonElement("LastName")]
    [Display(Name = "Sobrenome")]
    public string? LastName { get; set; }

  [BsonElement("Password")]
    [Display(Name = "Senha")]
    [System.ComponentModel.DataAnnotations.Required(ErrorMessage ="O campo senha é obrigatorio")]
    [StringLength(14, MinimumLength = 6, ErrorMessage ="A senha deve ter entre 6 a 14 caracteres")]
    public string? Password { get; set; }

}