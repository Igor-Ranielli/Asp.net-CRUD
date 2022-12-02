using MongoDB.Driver;

namespace PIM_VIII_CRUD.Models
{
    public class PessoaDAO
    {
        public static string ConnectionString { get; set; }
        public static string DatabaseName { get; set; }
        public static bool IsSSL { get; set; }
        private IMongoDatabase _database { get; }

        public PessoaDAO()
        {
            try
            {
                MongoClientSettings setting = MongoClientSettings.
                    FromUrl(new MongoUrl(ConnectionString));

                if (IsSSL)
                {
                    setting.SslSettings = new SslSettings
                    {
                        EnabledSslProtocols = System.Security.Authentication.SslProtocols.Tls12
                    };
                }

                var mongoCliente = new MongoClient(setting);
                _database = mongoCliente.GetDatabase(DatabaseName);
            }
            catch (Exception)
            {

                throw new Exception("Não foi possível conectar");
            }
        }

        public IMongoCollection<Pessoa> Pessoa
        {
            get
            {
                return _database.GetCollection<Pessoa>("Pessoa");
            }
        }
    }
}