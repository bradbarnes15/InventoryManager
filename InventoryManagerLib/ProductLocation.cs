using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagerLib
{
    public class ProductLocation : DBConnection
    {
        private int Locations_Id { get; set; }
        public string Product_Location { get; set; }
        public int Product_Quantity { get; set; }


        public ProductLocation(string Product_Location)
        {
            this.Product_Location = Product_Location;
            Product_Quantity = 0;
            Locations_Id = -1;
        }

        public ProductLocation(string Product_Location, int Product_Quantity)
        {
            this.Product_Location = Product_Location;
            this.Product_Quantity = Product_Quantity;
            Locations_Id = -1;
        }

        private ProductLocation(int Locations_Id, string Product_Location, int Product_Quantity)
        {
            this.Product_Location = Product_Location;
            this.Product_Quantity = Product_Quantity;
            this.Locations_Id = Locations_Id;
        }



    }
}
