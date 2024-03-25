using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order_Management_System.Model
{
    internal class Order
    {
        public int OrderId {get; set;}
        public int UserId { get; set;}
        public int ProductId { get; set;}

        public Order()
        {
            
        }

        public override string ToString()
        {
            return $"{OrderId} {UserId} {ProductId}";
        }

    }
}
