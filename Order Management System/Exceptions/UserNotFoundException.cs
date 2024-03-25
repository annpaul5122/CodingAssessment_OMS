using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Order_Management_System.Repository;

namespace Order_Management_System.Exceptions
{
    internal class UserNotFoundException : Exception
    {
        public UserNotFoundException(string message):base(message)
        {
            
        }

        public static void UserNotFound(int userId)
        {
            OrderProcessor orderProcessor = new OrderProcessor();
            if(!orderProcessor.UserExists(userId))
            {
                throw new UserNotFoundException("User not found");
            }
        }
    }
}
