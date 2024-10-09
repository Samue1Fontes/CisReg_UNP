using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CisReg_Project.Data {
    /// <summary>
    /// Essa classe tem como proposito servir de base para todos os tipos de dados
    /// com o proposito de permitir a generalização dos objetos com o banco de dados
    /// </summary>
    public class DataFoundation {

        // Propriedade representando o indice no banco
        [BsonRepresentation(BsonType.Int32)]
        private int Id { get; set; }

    }
}