using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp1.ServiceReference1;

using MongoDB.Bson;
using MongoDB.Driver;

namespace ConsoleApp1
{
    class Program
    {
        public BsonDocument[] strAll;
        static void Main(string[] args)
        {

            var bdd = new MongoClient("mongodb://localhost:27017");
            var database = bdd.GetDatabase("DBR");
            var collect = database.GetCollection<BsonDocument>("device");

            var documnt = new BsonDocument
            {
                {"Id_Device", 1 },
                {"name", "devicelight"},
                {"date", "01/01/01"},
                {"Value", "23"},
                {"NumberValue", "2"},
                {"GPSPosition_X", "01.55.42"},
                {"GPSPosition_Y", "01.55.42"},
                {"Id_User", "1"},
                {"MacAddress", "1"},


            };

            collect.InsertOneAsync(documnt);
            
            //var str = (BsonDocument)null;
            //BsonDocument[] str2;
            collect.Find(new BsonDocument()).ForEachAsync(X => Console.WriteLine(X));

            

            Service1Client client = new Service1Client();

            Console.WriteLine("-----------------");
            Console.WriteLine(client.sum(1, 2));
            //client.avg();

            Console.ReadKey();
        }

    }
}
