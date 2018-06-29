using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;

namespace DeviceManager.Models
{
    public class Device
    {
        [BsonId]
        public int Id_Device { get; set; }

        [BsonElement("Name")]
        public string Name { get; set; }

        [BsonElement("ValueIsInt")]
        public bool ValueIsInt { get; set; }

        [BsonElement("Date")]
        public DateTime Date { get; set; }

        [BsonElement("Value")]
        public double Value { get; set; }

        [BsonElement("NumberValue")]
        public int? NumberValue { get; set; }

        [BsonElement("GPSPosition_X")]
        public double GPSPosition_X { get; set; }

        [BsonElement("GPSPosition_Y")]
        public double GPSPosition_Y { get; set; }

        [BsonElement("Id_User")]
        public int? Id_User { get; set; }

        [BsonElement("MacAddress")]
        public string MacAddress { get; set; }
    }
}