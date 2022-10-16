using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Api_Consuming_Login.Models
{
    public class Login
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
    public class Registration : Employeemaster { }
}
