using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDbService
{
    public class LoggerHelper
    {
        public LoggerHelper(IDictionary<string, string> keyValues,string dataBaseName)
        {
           var database= MongoDbConnectorHelper.MongoDataBase(dataBaseName);
           var collection= database.GetCollection<BsonDocument>("Logger");
            BsonDocument bsonElements = new BsonDocument();

            foreach (KeyValuePair<string, string> p in keyValues)
            {
                bsonElements.Add(p.Key.ToString(), p.Value.ToString());
            }
           
            collection.InsertOne(bsonElements);

        }
    }
}
