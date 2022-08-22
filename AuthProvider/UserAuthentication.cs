using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaskManagementAPI.AuthProvider
{
    public class UserAuthentication:IDisposable
    {
        public User ValidateUser(string username, string password)
        {
            var user = new UserManager().FindUser(username, password);
            return user;
           
        }
        public void Dispose()
        {
            //Dispose();  
        }
    }
}