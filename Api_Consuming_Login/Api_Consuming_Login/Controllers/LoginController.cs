using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using Api_Consuming_Login.Models;
namespace Api_Consuming_Login.Controllers
{
    public class LoginController : ApiController
    {
        [EnableCors(origins: "http://localhost:4200/", headers: "*", methods: "*")]
        [Route("Api/Login/UserLogin" )]
        [HttpPost]
        public Response Login(Login lg)

        {
            EmployeeEntities EB = new EmployeeEntities ();
            var obj = EB.Form_Login(lg.UserName, lg.Password).ToList<Form_Login_Result>().FirstOrDefault();

            if (obj.Status == 0)
            {
                return new Response { Status = "invalid", Message = "invaliduser" };
            }
            if (obj.Status == -1)
            {
                return new Response { Status = "invalid", Message = "invaliduser" };
            }
            else
                return new Response { Status = "Success", Message = lg.UserName };
        }
        [Route("Api/Login/CreateContact")]
        [HttpPost]
        public Object CreateContact(Registration Rg) {
            try
            {
                EmployeeEntities EE = new EmployeeEntities ();
                Employeemaster EM = new Employeemaster();
                if (EM.UserId == 0)
                {
                    EM.UserName = Rg.UserName;
                    EM.LoginName = Rg.LoginName;
                    EM.Password = Rg.Password;
                    EM.Status = Rg.Status;
                    EM.Address = Rg.Address;
                    EM.ContactNo = Rg.ContactNo;
                    EM.IsApporved = Rg.IsApporved;
                    EM.TotalCnt = Rg.TotalCnt;
                    EE.Employeemasters.Add(EM);
                    EE.SaveChanges();
                    return new Response { Status = "Success", Message = "Successfully saved" };

                }

                
            }
            catch (Exception)
            {

                throw;

            }
            return new Response { Status = "Error", Message = "Invalid data" };
        }
    }
}
