using Order_Management_System.Order_Management;

namespace Order_Management_System
{
    internal class Program
    {
        static void Main(string[] args)
        {
            OrderManagement orderManagement = new OrderManagement();
            orderManagement.HandleMenu();
        }
    }
}
