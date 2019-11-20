using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using Skopei.Models;

namespace Skopei.Controllers
{
    public class UsersController : ApiController
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string Get()
        {
            var response = new Result<List<UserInfo>>();
            response = SkopeiDBHelper.GetUsers();
            return Newtonsoft.Json.JsonConvert.SerializeObject(response);
            
        }
       
        /// Post cause if this fucntion will run two times, there will be 2 record. What we want to do is run in only one time.
        /// There should be also unique record control based on email. and Unit Test should be done too. 
        /// I use log4net for logging and create global try catch so I do not write try catch in everwhere, handle it globally. (//Global.asax)
        [HttpPost]
        public string Post(UserInfo UInfo)
        {
            var response = new Result<string>();
            if (ModelState.IsValid)
            {
                if (Tools.EmailValidCheck(UInfo.Email) == false || UInfo.Email.Replace(" ","").Count()< 3 || UInfo.Name.Replace(" ", "").Count() < 3)
                {
                    response.Status = false;
                }
                response = SkopeiDBHelper.CreateUser(UInfo);
            }
            else
            {
                response.Status=false;
                response.Error = "Invaild inputs";
            }
            return  Newtonsoft.Json.JsonConvert.SerializeObject(response);
            
        }

    }
}