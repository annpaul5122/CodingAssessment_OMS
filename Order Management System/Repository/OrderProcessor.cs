﻿using Order_Management_System.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Order_Management_System.Utility;
using System.Diagnostics.Contracts;
using System.Security.Principal;

namespace Order_Management_System.Repository
{
    internal class OrderProcessor : IOrderManagementRepository
    {
        SqlConnection connect = null;
        SqlCommand cmd = null;

        public OrderProcessor()
        {
            connect = new SqlConnection(DatabaseConnectivity.GetConnectionString());
            cmd = new SqlCommand();
        }
        public bool cancelOrder(int userId, int orderId)
        {
            cmd.CommandText = "Delete from [Order] where userId=@user and orderId=@order";
            cmd.Parameters.AddWithValue("@user", userId);
            cmd.Parameters.AddWithValue("@order", orderId);
            connect.Open();
            cmd.Connection = connect;
            int status = cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            connect.Close();
            if (status > 0)
                return true;
            return false;
        }

        public bool createOrder(User user, Product product)
        {
            int status = 0;
            if(UserExists(user.UserId))
            {
                cmd.CommandText = "Insert into [Order] values(@userId,@productId)";
                cmd.Parameters.AddWithValue("@productId", product.ProductId);
                cmd.Parameters.AddWithValue("@userId", user.UserId);
                connect.Open();
                cmd.Connection = connect;
                status = cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
                connect.Close();
            }
            else
            {
                connect.Open();
                cmd.Connection = connect;
                cmd.CommandText = "Insert into [User] values (@name,@pwd,@role)";
                cmd.Parameters.AddWithValue("@name", user.UserName);
                cmd.Parameters.AddWithValue("@pwd", user.Password);
                cmd.Parameters.AddWithValue("@role", user.Role);
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
                connect.Close();
                connect.Open();
                cmd.CommandText = "Insert into [Order] values(@userId,@productId)";
                cmd.Parameters.AddWithValue("@productId", product.ProductId);
                cmd.Parameters.AddWithValue("@userId", user.UserId);
                status = cmd.ExecuteNonQuery();
                connect.Close();
                cmd.Parameters.Clear();
                connect.Close();    
            }
            if (status > 0)
                return true;
            return false;
        }

        public bool UserExists(int userId)
        {
            int count = 0;
            cmd.CommandText = "Select count(*) as totalcount from [User] where userId=@user_id";
            cmd.Parameters.AddWithValue("@user_id", userId);
            connect.Open();
            cmd.Connection = connect;
            SqlDataReader reader = cmd.ExecuteReader();
            while(reader.Read())
            {
                count = (int)reader["totalcount"];
            }
            connect.Close();
            if (count > 0)
                return true;
            return false;
        }

        public bool IfAdminOrNot(int id)
        {
            string role = "";
            try
            {
                cmd.CommandText = "select [role] from [User] where userId = @id";
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Connection = connect;

                connect.Open();

                SqlDataReader r = cmd.ExecuteReader();
                while(r.Read())
                {
                    role = (string)r["role"];
                }
                if (role.Equals("Admin"))
                {
                    return true;
                }

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return false;
        }

        public bool createProduct(User user, Product product)
        {
            int status = 0;
            
                cmd.CommandText = "Insert into Product values (@name,@desc,@price,@qty,@type)";
                cmd.Parameters.AddWithValue("@name",product.ProductName);
                cmd.Parameters.AddWithValue("@desc", product.Description);
                cmd.Parameters.AddWithValue("@price", product.Price);
                cmd.Parameters.AddWithValue("@qty", product.QuantityInStock);
                cmd.Parameters.AddWithValue("@type", product.Type);
                connect.Open();
                cmd.Connection = connect;
                status=cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
                connect.Close();
           
            if (status > 0)
                return true;
            return false;
        }

        public bool createUser(User user)
        {
            cmd.CommandText = "Insert into [User] values (@name,@pwd,@role)";
            cmd.Parameters.AddWithValue("@name", user.UserName);
            cmd.Parameters.AddWithValue("@pwd", user.Password);
            cmd.Parameters.AddWithValue("@role", user.Role);
            connect.Open();
            cmd.Connection = connect;
            int status=cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            connect.Close();
            if (status > 0)
                return true;
            return false;
        }

        public List<Product> getAllProducts()
        {
            List<Product> products = new List<Product>();
            cmd.CommandText = "Select * from Product";
            connect.Open();
            cmd.Connection = connect;
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Product product = new Product();
                product.ProductId= (int)reader["productId"];
                product.ProductName = (string)reader["productName"];
                product.Description= (string)reader["description"];
                product.Price = (decimal)reader["price"];
                product.QuantityInStock = Convert.IsDBNull(reader["quantityInStock"])?null:(int)reader["quantityInStock"];
                product.Type = (string)reader["type"];
                products.Add(product);
            }
            connect.Close();
            return products;
        }

        public List<Product> getOrderByUser(User user)
        {
            List<Product> products = new List<Product>();
            cmd.CommandText = "Select * from Product p join [Order] o on p.productId=o.productId where o.userId=@userid";
            cmd.Parameters.AddWithValue("@userid", user.UserId);
            connect.Open();
            cmd.Connection = connect;
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Product product = new Product();
                product.ProductId = (int)reader["productId"];
                product.ProductName = (string)reader["productName"];
                product.Description = (string)reader["description"];
                product.Price = (decimal)reader["price"];
                product.QuantityInStock = Convert.IsDBNull(reader["quantityInStock"]) ? null : (int)reader["quantityInStock"];
                product.Type = (string)reader["type"];
                products.Add(product);
            }
            connect.Close();
            cmd.Parameters.Clear();
            return products;
        }

        public bool OrderExists(int orderId)
        {
            int count = 0;
            cmd.CommandText = "Select count(*) as total from [Order] where orderId=@id";
            cmd.Parameters.AddWithValue("@id", orderId);
            connect.Open();
            cmd.Connection = connect;
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                count = (int)reader["total"];
            }
            connect.Close();
            if (count > 0)
                return true;
            return false;
        }
    }
}
