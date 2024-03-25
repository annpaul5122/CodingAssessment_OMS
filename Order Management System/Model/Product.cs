using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order_Management_System.Model
{
    internal class Product
    {
        private int productId;
        private string productName;
        private string description;
        private decimal price;
        private int? quantityInStock;
        private string type;
       
        public int ProductId {  get { return productId; } set {  productId = value; } }
        public string ProductName { get {  return productName; } set { productName = value; } }
        public string Description { get { return description; } set { description = value; } }
        public decimal Price { get { return price; } set { price = value; } }
        public int? QuantityInStock { get {  return quantityInStock; } set {  quantityInStock = value; } }
        public string Type { get { return type; }
        set {
                if (value == "Electronics" || value == "Clothing")
                {
                    type = value;
                }
                else
                    throw new ArgumentException("Type must only be Electronics or Clothing");
            }
        }


        public Product()
        {
            
        }

        public Product(int productId,string productName,string description,decimal price,int stock,string type)
        {
            ProductId = productId;
            ProductName = productName;
            Description = description;
            Price = price;
            QuantityInStock = stock;
            Type = type;
        }

        public override string ToString()
        {
            return $"{ProductId} {ProductName} {Description} {Price} {QuantityInStock} {Type}";
        }
    }
}
