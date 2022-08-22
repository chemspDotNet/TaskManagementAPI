using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaskManagementAPI.AuthProvider
{
    public  class UserManager
    {
        private static List<User> users = new List<User>()
       {
           new User(){ Username = "Admin", ConfirmPassword="admin", Password="admin", Role="admin"}
       };

      public User FindUser(string Username, string Password)
        {
           return  users.Find(x => x.Username == Username && x.Password == Password);
           
        }
      public void CreateUser(User user)
        {
            users.Add(user);
        }
    }
}