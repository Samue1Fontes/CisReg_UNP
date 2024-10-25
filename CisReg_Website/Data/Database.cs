using CisReg_Website.Models;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;

namespace CisReg_Website.Data
{
    /// <summary>
    /// Classe do banco de dados usando o padrão singleton com metodos que implementam o CRUD
    /// </summary>
    public class Database
    {

        // String de conexão com o cluster do projeto armazenado no serviço do mongodb
        private const string connectionString = "mongodb+srv://root:admin@cisreg.kzr70.mongodb.net/?retryWrites=true&w=majority&appName=CisReg";

        // Instância do singleton
        private static Database? instance;

        // Instância da conexão com o serviço do mongodb
        private MongoClient client;
        // Instância do banco obtido atravez do serviço do mongodb
        private IMongoDatabase database;

        /// <summary>
        /// onstrutor privado da classe
        /// </summary>
        private Database()
        {
            client = new MongoClient(connectionString);
            database = client.GetDatabase("cisreg");

            // Mapeamento de classes

            BsonClassMap.RegisterClassMap<CombinedInfoModel>(map => {
                map.AutoMap();
                map.MapCreator(c => new CombinedInfoModel());
            });
        }

        /// <summary>
        /// Essa função implementa o padrão singleton
        /// </summary>
        /// <returns>Instância do banco de dados</returns>
        public static Database GetInstance()
        {
            // Verifica se a instância está vazia, caso esteja cria uma nova instância da classe
            if (instance is null)
            {
                instance = new Database();
            }
            return instance;
        }

        /// <summary>
        /// Implementa a seleção dos dados contidos nos bancos
        /// </summary>
        /// <param name="collectionName">Nome da coleção (tabela) do banco</param>
        /// <param name="filter">Definição do filtro para o processo de busca, deixar nullo para buscar por tudo</param>
        /// <returns>Retorna uma lista dos objetos encontrados no banco se não o retorno é nulo</returns>
        public List<BsonDocument>? Select(string collectionName, FilterDefinition<BsonDocument>? filter)
        {
            try
            {
                var collection = database.GetCollection<BsonDocument>(collectionName);
                if (filter == null)
                {
                    return collection.FindAsync(new BsonDocument()).Result.ToList();
                }
                return collection.FindAsync(filter).Result.ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        /// <summary>
        /// Insere um novo objeto no banco
        /// </summary>
        /// <param name="collectionName">Nome da coleção (tabela) do banco</param>
        /// <param name="value">Objecto a ser inserido no banco</param>
        public void Insert(string collectionName, BsonDocument value)
        {
            try
            {
                database.GetCollection<BsonDocument>(collectionName).InsertOneAsync(value);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// Atualiza os dados encontrados no banco
        /// </summary>
        /// <param name="collectionName">Nome da coleção (tabela) do banco</param>
        /// <param name="filter">Definição do filtro para o processo de busca</param>
        /// <param name="update">Definição dos valores para o processo de atualização</param>
        public void Update(string collectionName, FilterDefinition<BsonDocument> filter, UpdateDefinition<BsonDocument> update)
        {
            try
            {
                var collection = database.GetCollection<BsonDocument>(collectionName);
                collection.UpdateOneAsync(filter, update);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// Deleta os dados do banco
        /// </summary>
        /// <param name="collectionName">Nome da coleção (tabela) do banco</param>
        /// <param name="filter">Definição do filtro para o processo de busca</param>
        public void Delete(string collectionName, FilterDefinition<BsonDocument> filter)
        {
            try
            {
                var collection = database.GetCollection<BsonDocument>(collectionName);
                collection.DeleteOneAsync(filter);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
