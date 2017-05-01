using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class ProductLocation : DBConnection
{
    public int    Locations_Id     { get; private set; }
    public string Product_Location { get; private set; }
    public int    Product_Quantity { get; private set; }
    public string Product_Code     { get; private set; }

    ObservableCollection<ProductLocation> tmp = new ObservableCollection<ProductLocation>();

   

    public ProductLocation(string Product_Location, string Product_Code)
    {
        this.Product_Location = Product_Location;
        this.Product_Code     = Product_Code;
        Product_Quantity = 0;
        Locations_Id = -1;
    }
    public ProductLocation(int id,string Product_Location,int prodQuanity, string Product_Code)
    {
        this.Product_Location = Product_Location;
        this.Product_Code = Product_Code;
        Product_Quantity = prodQuanity;
        Locations_Id = id;
    }
    public ProductLocation()
    {
    }

    public ProductLocation(string Product_Location, string Product_Code, int Product_Quantity)
    {
        this.Product_Location = Product_Location;
        this.Product_Quantity = Product_Quantity;
        this.Product_Code     = Product_Code;
        Locations_Id = -1;
    }

    private ProductLocation(int Locations_Id, string Product_Location, string Product_Code, int Product_Quantity)
    {
        this.Product_Location = Product_Location;
        this.Product_Quantity = Product_Quantity;
        this.Product_Code     = Product_Code;
        this.Locations_Id = Locations_Id;
    }

    /// <summary>
    /// Function to update the quantity of the item at the location
    /// </summary>
    /// <param name="Locations_Id"></param>
    /// <param name="Product_Quantity"></param>
    public static void UpdateQuantity(string Locations_Id, int Product_Quantity)
    {
        ProductLocation item = ProductLocation.Get(Locations_Id);

        item.Product_Quantity = Product_Quantity;

        item.Save();
    }


    /// <summary>
    /// Function to update what item is at a specific location
    /// </summary>
    /// <param name="Locations_Id">value to find the location in the database</param>
    /// <param name="Product_Code">new value for the item at the location</param>
    /// <param name="Product_Quantity">Quantity of the new item at the location</param>
    public static void ChangeItemAtLocation(string Locations_Id, string Product_Code, int Product_Quantity)
    {
        ProductLocation item = ProductLocation.Get(Locations_Id);

        item.Product_Code     = Product_Code;
        item.Product_Quantity = Product_Quantity;

        item.Save();
    }


    public static void RemoveItemAtLocation(string Locations_Id)
    {
        ProductLocation item = ProductLocation.Get(Locations_Id);

        item.Product_Code = "Empty";

        item.Save();
    }
    


    public void Save()
    {
        using (SqlConnection conn = new SqlConnection())
        {
            conn.ConnectionString = DBConnection.CONNECTION_STRING;
            conn.Open();

            string sql;

            if (Locations_Id == -1)
            {
                sql = "INSERT INTO Product_Locations(Product_Location, Product_Quantity, Product_Code) "
                    + "VALUES(@Product_Location, @Product_Quantity, @Product_Code) "
                    + "SELECT CAST (scope_identity() as int)";
            }
            else
            {
                sql = "UPDATE Product_Locations "
                    + "set Product_Location = @Product_Location, Product_Quantity = @Product_Quantity, Product_Code = @Product_Code "
                    + "WHERE Locations_Id = @Locations_Id";
            }

            SqlCommand command = new SqlCommand(sql, conn);
            command.Parameters.AddWithValue("Product_Location", Product_Location);
            command.Parameters.AddWithValue("Product_Quantity", Product_Quantity);
            command.Parameters.AddWithValue("Product_Code", Product_Code);

            if (Locations_Id == -1)
            {
                Locations_Id = (int)command.ExecuteScalar();
            }
            else
            {
                command.Parameters.AddWithValue("Locations_Id", Locations_Id);
                command.ExecuteNonQuery();
            }

        }
    }

    public static ProductLocation Get(int Locations_Id)
    {
        using (SqlConnection conn = new SqlConnection())
        {
            conn.ConnectionString = DBConnection.CONNECTION_STRING;
            conn.Open();

            string sql = "SELECT Locations_Id, Product_Location, Product_Quantity, Product_Code "
                       + "FROM Product_Locations "
                       + "WHERE Locations_Id = @Locations_Id";

            SqlCommand command = new SqlCommand(sql, conn);
            command.Parameters.AddWithValue("Locations_Id", Locations_Id);

            using (SqlDataReader read = command.ExecuteReader())
            {
                if (read.HasRows)
                {
                    read.Read();

                    ProductLocation location = new ProductLocation(
                                               read.GetInt32(0),
                                               read.GetString(1),
                                               read.GetString(3),
                                               read.GetInt32(2));
                    return location;
                }
                else
                {
                    return null;
                }
            }
        }
    }

    public static ProductLocation Get(string Product_Location)
    {
        using (SqlConnection conn = new SqlConnection())
        {
            conn.ConnectionString = DBConnection.CONNECTION_STRING;
            conn.Open();

            string sql = "SELECT Locations_Id, Product_Location, Product_Quantity, Product_Code "
                       + "FROM Product_Locations "
                       + "WHERE Product_Location = @Product_Location";

            SqlCommand command = new SqlCommand(sql, conn);
            command.Parameters.AddWithValue("Product_Location", Product_Location);

            using (SqlDataReader read = command.ExecuteReader())
            {
                if (read.HasRows)
                {
                    read.Read();

                    ProductLocation location = new ProductLocation(
                                               read.GetInt32(0),
                                               read.GetString(1),
                                               read.GetString(3),
                                               read.GetInt32(2));
                    return location;
                }
                else
                {
                    return null;
                }
            }
        }
    }

    public static List<ProductLocation> GetAll()
    {
        using (SqlConnection conn = new SqlConnection())
        {
            conn.ConnectionString = DBConnection.CONNECTION_STRING;
            conn.Open();

            string sql;

            sql = "SELECT Locations_Id, Product_Location, Product_Quantity, Product_Code "
                + "FROM Product_Locations";

            SqlCommand command = new SqlCommand(sql, conn);
            using (SqlDataReader reader = command.ExecuteReader())
            {
                List<ProductLocation> locationList = new List<ProductLocation>();

                while (reader.Read())
                {
                    ProductLocation pl = new ProductLocation(
                                               reader.GetInt32(0),
                                               reader.GetString(1),
                                               reader.GetString(3),
                                               reader.GetInt32(2));
                    locationList.Add(pl);
                }

                return locationList;
            }
        }
    }

    public static List<ProductLocation> GetAllEmpty()
    {
        using (SqlConnection conn = new SqlConnection())
        {
            conn.ConnectionString = DBConnection.CONNECTION_STRING;
            conn.Open();

            string sql;

            sql = "SELECT Locations_Id, Product_Location, Product_Quantity, Product_Code "
                + "FROM Product_Locations "
                + "WHERE Product_Code = 'Empty'";

            SqlCommand command = new SqlCommand(sql, conn);
            using (SqlDataReader reader = command.ExecuteReader())
            {
                List<ProductLocation> locationList = new List<ProductLocation>();

                while (reader.Read())
                {
                    ProductLocation pl = new ProductLocation(
                                               reader.GetInt32(0),
                                               reader.GetString(1),
                                               reader.GetString(3),
                                               reader.GetInt32(2));
                    locationList.Add(pl);
                }

                return locationList;
            }
        }
    }


    public override string ToString()
    {
        return this.Product_Location;
    }

}

