using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace CisReg_Website.Data
{   
    /// <summary>
    /// Classe abstrata para centralizar os tipos de dados
    /// </summary>
    public class DataFoundation : BsonDocument
    {

        // Propriedade representando o indice no banco
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId Id { get; set; }

    }
}
