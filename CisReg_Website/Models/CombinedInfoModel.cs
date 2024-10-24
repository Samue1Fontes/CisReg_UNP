using CisReg_Website.Data;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.ComponentModel.DataAnnotations;

namespace CisReg_Website.Models
{

    public class CombinedInfoModel : DataFoundation
    {
        // Dados Pessoais
        [BsonRepresentation(BsonType.String)]
        public string CompleteName { get; set; } = string.Empty;

        [BsonRepresentation(BsonType.String)]
        public string Email { get; set; } = string.Empty;

        [BsonRepresentation(BsonType.String)]
        public string CPF { get; set; } = string.Empty;

        [BsonRepresentation(BsonType.DateTime)]
        [DataType(DataType.Date)]
        public DateTime BornDate { get; set; }

        [BsonRepresentation(BsonType.String)]
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;

        // Dados Profissionais
        [BsonRepresentation(BsonType.String)]
        public string registrationNumber { get; set; } = string.Empty;

        [BsonRepresentation(BsonType.String)]
        public string specialty { get; set; } = string.Empty;

        [BsonRepresentation(BsonType.String)]
        public string academicTraining { get; set; } = string.Empty;
    }
}