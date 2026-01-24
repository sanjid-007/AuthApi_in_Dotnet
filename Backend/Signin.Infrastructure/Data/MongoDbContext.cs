using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace Signin.Infrastructure.Data
{
    public class MongoDbContext
    {
        public readonly IMongoDatabase _mongoDatabase;
        public MongoDbContext(IConfiguration configuration)
        {
            var client = new MongoClient(configuration["MongoDB:ConnectionString"]);
            _mongoDatabase = client.GetDatabase(configuration["MongoDB:DatabaseName"]);
        }
        public IMongoCollection<T> GetCollection<T>(string name)
        {
            return _mongoDatabase.GetCollection<T>(name);
        }
    }
}
