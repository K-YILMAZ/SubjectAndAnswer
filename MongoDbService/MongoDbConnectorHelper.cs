using MongoDB.Driver;

namespace MongoDbService
{
    public class MongoDbConnectorHelper
    {
        private static IMongoDatabase _mongoDatabase;
        private static MongoDbConnectorHelper _MongoDbConnectorHelper;
        public static IMongoDatabase MongoDataBase(string dataBaseName)
        {
            if (_MongoDbConnectorHelper == null)
            {
                _MongoDbConnectorHelper = new MongoDbConnectorHelper();
                _mongoDatabase = new MongoClient("mongodb://localhost:27017").GetDatabase(dataBaseName);
            }

            return _mongoDatabase;
        }
    }
}