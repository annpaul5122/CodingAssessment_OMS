using Order_Management_System.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order_Management_System.Exceptions
{
    internal class OrderIdNotFoundException : Exception
    {
        public OrderIdNotFoundException(string message):base(message)
        {
            
        }

        public static void OrderNotFound(int orderId)
        {
            OrderProcessor orderProcessor = new OrderProcessor();
            if(!orderProcessor.OrderExists(orderId))
            {
                throw new OrderIdNotFoundException("Order id not found");
            }
        }
    }
}
