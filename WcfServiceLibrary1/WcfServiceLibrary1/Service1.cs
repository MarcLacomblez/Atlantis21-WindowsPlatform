using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

using MongoDB.Bson;
using MongoDB.Bson.IO;
using MongoDB.Driver;
using Newtonsoft.Json.Linq;

namespace WcfServiceLibrary1
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class Service1 : IService1
    {
        public double avg()
        {
            var bdd = new MongoClient("mongodb://localhost:27017");
            var database = bdd.GetDatabase("DBR");
            var collect = database.GetCollection<BsonDocument>("device");

            var doc = collect.Find(new BsonDocument()).ToList();
            double[] myTable = new double[doc.Count];

            for (int i = 0; i < doc.Count; i++)
            {
                //Console.WriteLine(doc[i].ToJson());

                var jsonWriterSettings = new JsonWriterSettings { OutputMode = JsonOutputMode.Strict }; // key part

                dynamic data = JObject.Parse(doc[i].ToJson(jsonWriterSettings));
                //Console.WriteLine(data.Value);

                myTable[i] = data.Value;
            }


            double myresult = myTable.Average();
            return myresult;



        }


        //Important command

        /*double IService1.avg(string dateMode, string date)
        {

            var bdd = new MongoClient("mongodb://localhost:27017");
            var database = bdd.GetDatabase("DBR");
            var collect = database.GetCollection<BsonDocument>("device");

            BsonDocument filter = new BsonDocument(); 

            if (dateMode == "day")
            {
                 filter = new BsonDocument("Date", date);
            }

            else if(dateMode == "Month")
            {
                 filter = new BsonDocument();
            }
            else
            {
                 filter = new BsonDocument();
            }

            var documents = collect.Find(filter).ToList();

            double[] myTab = new double[documents.Count];

            for (int i = 0; i < documents.Count; i++)
            {

                var jsonWriterSettings = new JsonWriterSettings { OutputMode = JsonOutputMode.Strict }; // key part

                dynamic data = JObject.Parse(documents[i].ToJson(jsonWriterSettings));

                myTab[i] = data.Value;
            }


            double result = myTab.Average();
            return result;
        }*/




        //others

        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }



        int IService1.divide(int num1, int num2)
        {
            int result = num1 / num2;
            Console.WriteLine(result);
            return result;
        }

        string IService1.GetData(int value)
        {
            string result = value.ToString();
            return result;
        }

        CompositeType IService1.GetDataUsingDataContract(CompositeType composite)
        {
            throw new NotImplementedException();
        }


        /* Tuple<string, int> IService1.max(double[] num)
         {
             double myMaxValue = num.Max();

             return myMaxValue;
         }*/

        int IService1.multiply(int num1, int num2)
        {
            int result = num1 * num2;
            Console.WriteLine(result);
            return result;
        }

        int IService1.substract(int num1, int num2)
        {
            int result = num1 - num2;
            Console.WriteLine(result);
            return result;
        }

        int IService1.sum(int num1, int num2)
        {
            int result = num1 + num2;
            Console.WriteLine(result);
            return result;
        }

        int IService1.totalsum(int[] num)
        {
            int total = 0;
            int result = 0;

            for (int i = 0; i < num.Length; i++)
            {
                total += num[i];
            }

            Console.WriteLine(total);
            return total;
        }


    }
}
