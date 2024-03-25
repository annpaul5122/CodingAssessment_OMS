using Order_Management_System.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Order_Management_System.Service;
using Order_Management_System.Repository;

namespace Order_Management_System.Order_Management
{
    internal class OrderManagement
    {
        OrderProcessorService service = new OrderProcessorService();
        public void HandleMenu()
        {
            int choice = 0;
            User user;
            Product product;
            do
            {
                Console.WriteLine("Welcome to Order Management System");
                Console.WriteLine("Main Menu");
                Console.WriteLine("---------------");
                Console.WriteLine("Press 1: Create Order\nPress 2: Create Product\nPress 3: Create User\nPress 4: Cancel Order\nPress 5: Get All Products\nPress 6: Get order by id\nPress 7: Exit\n\n");
                Console.WriteLine("Enter your choice: ");
                choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        OrderProcessor order1 = new OrderProcessor();
                        Console.WriteLine("Enter user id: ");
                        int userId = int.Parse(Console.ReadLine());
                        User user1 = new User() { UserId = userId };
                        Console.WriteLine("Enter product id: ");
                        int productId = int.Parse(Console.ReadLine());
                        product = new Product() { ProductId = productId };
                        if (order1.UserExists(userId))
                            service.CreateNewOrder(user1, product);
                        else
                        {

                            Console.WriteLine("Enter username: ");
                            string name = Console.ReadLine();
                            Console.WriteLine("Enter password: ");
                            string pwd = Console.ReadLine();
                            Console.WriteLine("Enter Role (Admin/User): ");
                            string role = Console.ReadLine();
                            user = new User(userId,name,pwd,role);
                            service.CreateNewOrder(user, product);
                        }
                        break;

                    case 2:
                        OrderProcessor order =new OrderProcessor();
                        Console.WriteLine("Enter userid: ");
                        int u_id = int.Parse(Console.ReadLine());
                      
                        user = new User() { UserId = u_id };
                        if (order.UserExists(u_id) && order.IfAdminOrNot(u_id))
                        {
                            Console.WriteLine("Enter productid: ");
                            int p_id = int.Parse(Console.ReadLine());
                            Console.WriteLine("Enter productName: ");
                            string p_name = Console.ReadLine();
                            Console.WriteLine("Enter description: ");
                            string desc = Console.ReadLine();
                            Console.WriteLine("Enter price: ");
                            decimal price = decimal.Parse(Console.ReadLine());
                            Console.WriteLine("Enter quantity: ");
                            int qty = int.Parse(Console.ReadLine());
                            Console.WriteLine("Enter Type: ");
                            string type = Console.ReadLine();
                            product = new Product(p_id, p_name, desc, price, qty, type);
                            service.CreateNewProduct(user, product);
                        }
                        else
                            Console.WriteLine("Not an admin");
                        break;

                    case 3:
                        Console.WriteLine("Enter username: ");
                        string u_name = Console.ReadLine();
                        Console.WriteLine("Enter password: ");
                        string u_pwd = Console.ReadLine();
                        Console.WriteLine("Enter Role (Admin/User): ");
                        string user_role = Console.ReadLine();
                        user = new User() { UserName = u_name, Password = u_pwd, Role = user_role };
                        service.CreateNewUser(user);
                        break;

                    case 4:
                        Console.WriteLine("Enter userid: ");
                        int userid = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter orderid: ");
                        int orderid = int.Parse(Console.ReadLine());
                        service.CancelExistingOrder(userid, orderid);
                        break;

                    case 5:
                        Console.WriteLine("List of Products: ");
                        service.GetProducts();
                        break;

                    case 6:
                        Console.WriteLine("Enter userid: ");
                        int userID = int.Parse(Console.ReadLine());
                        user = new User() { UserId = userID };
                        service.GetOrder(user);
                        break;

                    case 7:
                        Console.WriteLine("Exiting...");
                        break;

                    default:
                        Console.WriteLine("Try again...");
                        break;

                }
            } while (choice != 7);
        }
    }
}
