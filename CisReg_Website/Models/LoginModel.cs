using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace CisReg_Website.Models;

public class LoginModel
{
  public string Email { get; set; } = string.Empty;

  [DataType(DataType.Password)]
  public string Password { get; set; } = string.Empty;
}