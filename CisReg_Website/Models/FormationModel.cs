using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CisReg_Website.Models;

public class FormationModel
{
    [BsonId]
    public ObjectId Id { get; set; }

    [BsonElement("nome")]
    public string? Name { get; set; }

}