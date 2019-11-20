using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Skopei.Models
{
    
    public class SkopeiDBHelper
    {
        public static Result<List<UserInfo>> GetUsers()
        {
            var result = new Result<List<UserInfo>>();
            // using -> help us to close the connection properly and having a private SkopeiDBEntities and using it all around the class is really dangerous.
            try
            {
                using (SkopeiDBEntities db = new SkopeiDBEntities())
                {
                    var q = from u in db.Users
                            where u.Deleted == false
                            select new UserInfo() { Name = u.Name, Email = u.Email };
                    result.Status = true;
                    result.Data = q.ToList();
                }
            }
            catch(Exception Ex)
            {
                result.Status = false;
                result.Error = "Unexpected error occured while getting user, please warn the IT to check the longs";
            }
            return result;
        }

        public static Result<string> CreateUser(UserInfo UserRecord)
        {
            var result = new Result<string>();
            try
            {
                using (SkopeiDBEntities db = new SkopeiDBEntities())
                {
                    Users U = new Users();
                    U.Email = UserRecord.Email.Trim();
                    U.Name = UserRecord.Name.Trim();
                    U.DateModified = DateTime.UtcNow;
                    U.DateCreated = DateTime.UtcNow;
                    U.Deleted = false;
                    db.Users.Add(U);
                    db.SaveChanges();
                    result.Status =true;
                    
                }
            }
            catch(Exception Ex)
            {
                // Ex info should be in our long, we send our prefered message to the client.
                result.Error = "Unexpected error occured while creating user, please warn the IT to check the longs";
                result.Status = false;
            }
            return result; 
        }
    }
}