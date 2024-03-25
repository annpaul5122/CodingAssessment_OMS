using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order_Management_System.Model
{
    internal class Electronics : Product
    {
        private string brand;
        private int warrantyPeriod;

        public string Brand {  get { return brand; } set {  brand = value; } }

        public int WarrantyPeriod { get {  return warrantyPeriod; } set {  warrantyPeriod = value; } }

        public Electronics() : base() 
        {
        }

        public override string ToString()
        {
            return $"{Brand} {WarrantyPeriod}";
        }
    }
}
