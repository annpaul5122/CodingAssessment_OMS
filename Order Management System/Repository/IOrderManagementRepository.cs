using Order_Management_System.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace Order_Management_System.Repository
{
    internal interface IOrderManagementRepository
    {
        bool createOrder(User user, Product product);
        bool cancelOrder(int userId, int orderId);
        bool createProduct(User user,Product product);
        bool createUser(User user);
        List<Product> getAllProducts();
        List<Product> getOrderByUser(User user);

    }
}
