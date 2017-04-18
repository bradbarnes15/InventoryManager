using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

public class Inventory : DBConnection
{
    private int Inventory_Id { get; set; }
    private string Product { get; set; }
    private int Product_Id { get; set; }
    private string Product_Location { get; set; }
    private int On_Hand { get; set; } 
	private int Reorder_Level { get; set; }
	private int Reorder_Quantity { get; set; }
    private int On_Order { get; set; }


    public Inventory(string Product, string Product_Location, int Product_Id, int On_Hand, int Reorder_Level, int Reorder_Quantity)
    {
        this.Product          = Product;
        this.Product_Id       = Product_Id;
        this.Product_Location = Product_Location;
        this.On_Hand          = On_Hand;
        this.Reorder_Level    = Reorder_Level;
        this.Reorder_Quantity = Reorder_Quantity;
        On_Order = 0;
    }
    
    private Inventory(int Inventory_Id, string Product, int Product_Id, string Product_Location, int On_Hand, int Reorder_Level, int Reorder_quantity, int On_Order)
    {
        this.Inventory_Id     = Inventory_Id;
        this.Product          = Product;
        this.Product_Id       = Product_Id;
        this.Product_Location = Product_Location;
        this.On_Hand          = On_Hand;
        this.Reorder_Level    = Reorder_Level;
        this.Reorder_Quantity = Reorder_Quantity;
        this.On_Order = On_Order;
    }


    public void Save()
    {
        using (SqlConnection conn = new SqlConnection())
        {
            conn.ConnectionString = DBConnection.CONNECTION_STRING;
            conn.Open();

            string sql;

            if (Inventory_Id == -1)
            {
                sql = "INSERT INTO Inventory(Product_Id, Product, Product_Location, On_Hand, Reorder_Level, Reorder_Quantity, On_Order)"
                    + "VALUES(@Product_Id, @Product, @Product_Location, @On_Hand, @Reorder_Level, @Reorder_Quantity, @On_Order)"
                    + "SELECT CAST (scope_identity() as int)";
            }
            else
            {
                sql = "UPDATE Inventory"
                    + "SET Product_Id = @Product_Id, Product = @Product, Product_Location = @Product_Location, On_Hand = @On_Hand, Reorder_Level = @Reorder_Level, Reorder_Quantity = @Reorder_Quantity, On_Order = @On_Order"
                    + "WHERE Inventory_Id = @Inventory_Id";
            }

            
            SqlCommand command = new SqlCommand(sql, conn);

            command.Parameters.AddWithValue("Product_Id", Product_Id);
            command.Parameters.AddWithValue("Product", Product);
            command.Parameters.AddWithValue("Product_Location", Product_Location);
            command.Parameters.AddWithValue("On_Hand", On_Hand);
            command.Parameters.AddWithValue("Reorder_Level", Reorder_Level);
            command.Parameters.AddWithValue("Reorder_Quantity", Reorder_Quantity);
            command.Parameters.AddWithValue("On_Order", On_Order);

            if (Inventory_Id == -1)
            {
                Inventory_Id = (int)command.ExecuteScalar();
            }
            else
            {
                command.Parameters.AddWithValue("Inventory_Id", Inventory_Id);
                command.ExecuteNonQuery();
            }
        }
    }


    public static Inventory Get(int IdValue)
    {
        using (SqlConnection conn = new SqlConnection())
        {
            conn.ConnectionString = DBConnection.CONNECTION_STRING;
            conn.Open();

            string sql = "SELECT Inventory_Id, Product, Product_Id, Product_Location, On_Hand, Reorder_Level, Reorder_Quantity, On_Order"
                       + "FROM Inventory"
                       + "WHERE Inventory_Id = Inventory_Id";

            SqlCommand command = new SqlCommand(sql, conn);
            command.Parameters.AddWithValue("Inventory_Id", IdValue);

            using (SqlDataReader read = command.ExecuteReader())
            {
                if (read.HasRows)
                {
                    read.Read();

                    Inventory inv = new Inventory(read.GetInt32(0),
                                                  read.GetString(2),
                                                  read.GetInt32(1),
                                                  read.GetString(3),
                                                  read.GetInt32(4),
                                                  read.GetInt32(5),
                                                  read.GetInt32(6),
                                                  read.GetInt32(7));
                    return inv;
                }
                else
                {
                    return null;
                }
            }
        }
    }


    public static List<Inventory> GetAll()
    {
        using (SqlConnection conn = new SqlConnection())
        {
            conn.ConnectionString = DBConnection.CONNECTION_STRING;
            conn.Open();

            string sql = "SELECT Inventory_Id, Product, Product_Id, Product_Location, On_Hand, Reorder_Level, Reorder_Quantity, On_Order"
                       + "FROM Inventory";

            SqlCommand command = new SqlCommand(sql, conn);
            using (SqlDataReader reader = command.ExecuteReader())
            {
                List<Inventory> invList = new List<Inventory>();

                while (reader.Read())
                {
                    Inventory item = new Inventory(reader.GetInt32(0),
                                                  reader.GetString(2),
                                                  reader.GetInt32(1),
                                                  reader.GetString(3),
                                                  reader.GetInt32(4),
                                                  reader.GetInt32(5),
                                                  reader.GetInt32(6),
                                                  reader.GetInt32(7));

                    invList.Add(item);
                }

                return invList;
            }
        }
    }



    public override string ToString()
	{
		throw new System.NotImplementedException();
	}

	public virtual void ModifyItemStock()
	{
		throw new System.NotImplementedException();
	}

	public virtual void setFiltersToOrder()
	{
		throw new System.NotImplementedException();
	}

}

