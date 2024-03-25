using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Order_Management_System.Repository;
using Order_Management_System.Model;
using Order_Management_System.Exceptions;

namespace Order_Management_System.Service
{
    internal class OrderProcessorService
    {
        private readonly OrderProcessor _order;

        public OrderProcessorService()
        {
            _order = new OrderProcessor();
        }

        public void CreateNewOrder(User user,Product product)
        {
            if (_order.createOrder(user, product))
                Console.WriteLine("Order created successfully");
            else
                Console.WriteLine("Unsuccesful");
        }

        public void CancelExistingOrder(int userId,int orderId)
        {
            try
            {
                UserNotFoundException.UserNotFound(userId);
                OrderIdNotFoundException.OrderNotFound(orderId);
                if (_order.cancelOrder(userId, orderId))
                    Console.WriteLine("Cancellation successful");
                else
                    Console.WriteLine("Cancellation unsuccessful");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }

        public void CreateNewProduct(User user,Product product)
        {
            if(_order.createProduct(user, product))
                Console.WriteLine("Product added successfully");
            else
                Console.WriteLine("Product not added");

        }

        public void CreateNewUser(User user)
        {
            if(_order.createUser(user))
                Console.WriteLine("User added successfully");
            else
                Console.WriteLine("User not added");
        }

        public void GetProducts()
        {
            foreach(Product item in _order.getAllProducts())
                Console.WriteLine(item);
        }

        public void GetOrder(User user)
        {
            try
            {
                UserNotFoundException.UserNotFound(user.UserId);
                foreach(Product item in _order.getOrderByUser(user))
                    Console.WriteLine(item);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        


    }
}
