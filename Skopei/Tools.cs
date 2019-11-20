using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Skopei
{
    public class Tools
    {
        public static bool EmailValidCheck(string email)
        {
            try
            {
                var address = new System.Net.Mail.MailAddress(email);
                return address.Address == email;
            }
            catch
            {
                return false;
            }
        }


    }
}