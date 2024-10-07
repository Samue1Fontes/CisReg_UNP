using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using MongoDB.Driver.Core.Configuration;

namespace CisReg_Project.Data {
    /// <summary>
    /// Classe do banco de dados usando o padrão singleton com metodos que implementam o CRUD
    /// </summary>
    public class Database {

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
        private Database() {
            client = new MongoClient(connectionString);
            database = client.GetDatabase("cisreg");
            
            /*
            TODO:
            Criar o mapeamneto de classes para o driver do mongodb reconhecer os objetos e suas respectivas classes
            alem de realizar a construção e leitura de cada propriedade

            BsonClassMap.RegisterClassMap<Classe>(map => {
                map.AutoMap();
                map.MapCreator(c => new Classe(...));
            });
            */
        }

        /// <summary>
        /// Essa função implementa o padrão singleton
        /// </summary>
        /// <returns>Instância do banco de dados</returns>
        public static Database GetInstance() {
            // Verifica se a instância está vazia, caso esteja cria uma nova instância da classe
            if (instance is null) {
                instance = new Database();
            }
            return instance;
        }

        // TODO: Implementar CRUD

        public void Select() {
            try {
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
        }

        public void Insert() {
            try {
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
        }

        public void Update() {
            try {
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
        }

        public void Delete() {
            try {
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
