using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order_Management_System.Model
{
    internal class User
    {
        private int userId;
        private string username;
        private string password;
        private string role;
         
        public int UserId { get { return userId; } set { userId = value; } }
        public string UserName { get { return username; } set { username = value; } }
        public string Password { get { return password; } set { password = value; } }
        public string Role { get { return role; }
        set
            {
                if (value == "Admin" || value == "User")
                    role = value;
                else
                    throw new ArgumentException("The role must only be Admin or User");
            }
        }


        public User()
        {
            
        }
         
        public User(int id,string name,string pwd,string role)
        {
            UserId = id;
            UserName = name;
            Password = pwd;
            Role = role;
        }

        public override string ToString()
        {
            return $"{UserId} {UserName} {Password} {Role}";
        }
    }
}
