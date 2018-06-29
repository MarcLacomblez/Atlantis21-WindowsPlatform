using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DeviceManager.Models
{
    public class User
    {
        [BsonId]
        public int Id_User { get; set; }

        [BsonElement("LastName")]
        public string LastName { get; set; }

        [BsonElement("FirstName")]
        public string FirstName { get; set; }

        [BsonElement("Email")]
        public string Email { get; set; }

        [BsonElement("isAdmin")]
        public bool IsAdmin { get; set; }

        [BsonElement("Date")]
        public DateTime Date { get; set; }

        [BsonElement("Comment")]
        public string Comment { get; set; }
    }
}