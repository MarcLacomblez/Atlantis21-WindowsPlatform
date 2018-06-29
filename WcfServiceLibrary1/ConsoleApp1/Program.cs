using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp1.ServiceReference1;

using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Bson.IO;
using Newtonsoft.Json.Linq;

namespace ConsoleApp1
{
    class Program
    {


        static void Main(string[] args)
        {

            var bdd = new MongoClient("mongodb://localhost:27017");
            var database = bdd.GetDatabase("DBR");
            var collect = database.GetCollection<BsonDocument>("device");

            var documnt = new BsonDocument
            {
                {"Id_Device", "5" },
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

            /*var filter = "{Id_Device : '5'}";
        
            collect.Find(filter).ForEachAsync(document => Console.WriteLine(document));*/

            List<dynamic> dataAll = new List<dynamic>();
            var documents = collect.Find(new BsonDocument()).ToList();

            double[] myTab = new double[documents.Count];

            for (int i = 0; i < documents.Count; i++)
            {
               

                var jsonWriterSettings = new JsonWriterSettings { OutputMode = JsonOutputMode.Strict }; // key part

                dynamic data = JObject.Parse(documents[i].ToJson(jsonWriterSettings));

                dataAll[i] = data;

                //myTab[i] = data.Value;
            }



            Service1Client client = new Service1Client();


           // Console.WriteLine(client.avg(myTab));

            //Console.WriteLine(client.sum(1, 2));

            Console.ReadKey();
        }

    }
}
