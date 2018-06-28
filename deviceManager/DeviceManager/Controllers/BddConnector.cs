using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using DeviceManager.ServiceReference1;

using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Bson.Serialization;


namespace DeviceManager.Controllers
{
    public class BddConnector
    {
        public void myConnection(string myJson)
        {
            var bdd = new MongoClient("mongodb://localhost:27017");
            var database = bdd.GetDatabase("DBR");

            var documnt = BsonSerializer.Deserialize<BsonDocument>(myJson);
            var collect = database.GetCollection<BsonDocument>("device");

            collect.InsertOneAsync(documnt);
            
        }

    }
}