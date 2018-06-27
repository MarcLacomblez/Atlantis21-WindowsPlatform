using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DeviceManager.Models
{
    public class User
    {
        public int Id_User { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Email { get; set; }
        public bool IsAdmin { get; set; }
        public DateTime Date { get; set; }
        public string Comment { get; set; }
    }
}