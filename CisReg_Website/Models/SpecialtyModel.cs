using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CisReg_Website.Models;

public class SpecialtyModel
{
    [BsonId] 
    public ObjectId Id { get; set; }

    [BsonElement("nome")]
    public string? Name { get; set; }

}