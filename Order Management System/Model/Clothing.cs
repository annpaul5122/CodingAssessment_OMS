using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order_Management_System.Model
{
    internal class Clothing : Product
    {
        private string size;
        private string color;

        public string Size { get { return size; } set {  size = value; } }
        public string Color { get { return color; } set { color = value; } }

        public Clothing() : base()
        {
            
        }

        public override string ToString()
        {
            return $"{Size} {Color}";
        }
    }
}
