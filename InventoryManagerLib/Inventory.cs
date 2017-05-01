﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

public class Inventory : DBConnection
{
    public int    Inventory_Id     { get; private set; }
    public string Product          { get; private set; }
    public string Product_Code     { get; private set; }
    public string Product_Location { get; private set; }
    public int    On_Hand          { get; private set; }
    public int    Reorder_Level    { get; private set; }
    public int    Reorder_Quantity { get; private set; }
    public int    On_Order         { get; private set; }


    public Inventory(string Product, string Product_Location, string Product_Code, int On_Hand, int Reorder_Level, int Reorder_Quantity)
    {
        this.Product          = Product;
        this.Product_Code     = Product_Code;
        this.Product_Location = Product_Location;
        this.On_Hand          = On_Hand;
        this.Reorder_Level    = Reorder_Level;
        this.Reorder_Quantity = Reorder_Quantity;
        this.On_Order         = 0;
        this.Inventory_Id     = -1;
    }
    
    private Inventory(int Inventory_Id, string Product, string Product_Code, string Product_Location, int On_Hand, int Reorder_Level, int Reorder_Quantity, int On_Order)
    {
        this.Inventory_Id     = Inventory_Id;
        this.Product          = Product;
        this.Product_Code     = Product_Code;
        this.Product_Location = Product_Location;
        this.On_Hand          = On_Hand;
        this.Reorder_Level    = Reorder_Level;
        this.Reorder_Quantity = Reorder_Quantity;
        this.On_Order         = On_Order;
    }


    /// <summary>
    /// Update the amount of stock shown as on_hand
    /// </summary>
    /// <param name="Product_Code">Value used to look up the item in the database</param>
    /// <param name="newStockLevel"></param>
    public void ModifyItemStock(int newStockLevel)
    {

        this.On_Hand = newStockLevel;
        ProductLocation.UpdateQuantity(this.Product_Location, newStockLevel);

        this.Save();
    }


    /// <summary>
    /// Function to Update the minimum amount before an automatic order is created for the item
    /// and how much it will add to that order
    /// </summary>
    /// <param name="Product_Id">Value used to look up the item in the database</param>
    /// <param name="MinimumAmount">New value to be used for Reorder_Level</param>
    /// <param name="ReorderQuantity">New value to be used for Reorder_Quantity</param>
    public static void setFiltersToOrder(int Product_Id, int MinimumAmount, int ReorderQuantity)
    {
        Inventory item = Inventory.Get(Product_Id);

        item.Reorder_Level    = MinimumAmount;
        item.Reorder_Quantity = ReorderQuantity;

        item.Save();
    }


    /// <summary>
    /// Function to update the quantity that will be ordered by the auto order
    /// </summary>
    /// <param name="Product_Id">Value to look up the item in database</param>
    /// <param name="ReorderQuantity">New amount for the Reorder_Quantity</param>
    public static void UpdateReorderQuantity(int Product_Id, int ReorderQuantity)
    {
        Inventory item = Inventory.Get(Product_Id);

        item.Reorder_Quantity = ReorderQuantity;

        item.Save();
    }


    /// <summary>
    /// Function to update the Reorder_Level of an item
    /// -the minimum amount allowed before an auto order is created
    /// </summary>
    /// <param name="Product_Id"></param>
    /// <param name="ReorderLevel"></param>
    public static void UpdateReorderLevel(int Product_Id, int ReorderLevel)
    {
        Inventory item = Inventory.Get(Product_Id);

        item.Reorder_Level = ReorderLevel;

        item.Save();
    }


    /// <summary>
    /// Function to update how many items are currently On_Order
    /// </summary>
    /// <param name="Product_Id"></param>
    /// <param name="On_Order"></param>
    public void UpdateOnOrderQuantity( int On_Order)
    {
        this.On_Order = On_Order;

        this.Save();
    }

    /// <summary>
    /// Function to update the location of the product
    /// </summary>
    /// <param name="Product_Id"></param>
    /// <param name="NewLocations_Id"></param>
    /// <param name="NewLocation"></param>
    public static void UpdateProductLocation(int Product_Id, string CurrLocations_Id, string NewLocations_Id, string NewLocation)
    {
        Inventory item = Inventory.Get(Product_Id);

        item.Product_Location = NewLocation;
        ProductLocation.ChangeItemAtLocation(NewLocations_Id, NewLocation, item.On_Hand);
        ProductLocation.RemoveItemAtLocation(CurrLocations_Id);

        item.Save();
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
                sql = "INSERT INTO Inventory(Product_Code, Product, Product_Location, On_Hand, Reorder_Level, Reorder_Quantity, On_Order) "
                    + "VALUES(@Product_Code, @Product, @Product_Location, @On_Hand, @Reorder_Level, @Reorder_Quantity, @On_Order) "
                    + "SELECT CAST (scope_identity() as int)";
            }
            else
            {
                sql = "UPDATE Inventory "
                    + "SET Product_Code = @Product_Code, Product = @Product, Product_Location = @Product_Location, On_Hand = @On_Hand, Reorder_Level = @Reorder_Level, Reorder_Quantity = @Reorder_Quantity, On_Order = @On_Order "
                    + "WHERE Inventory_Id = @Inventory_Id";
            }

            
            SqlCommand command = new SqlCommand(sql, conn);

            command.Parameters.AddWithValue("Product_Code", Product_Code);
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

            string sql = "SELECT Inventory_Id, Product, Product_Code, Product_Location, On_Hand, Reorder_Level, Reorder_Quantity, On_Order "
                       + "FROM Inventory "
                       + "WHERE Inventory_Id = @Inventory_Id";

            SqlCommand command = new SqlCommand(sql, conn);
            command.Parameters.AddWithValue("Inventory_Id", IdValue);

            using (SqlDataReader read = command.ExecuteReader())
            {
                if (read.HasRows)
                {
                    read.Read();

                    Inventory inv = new Inventory(read.GetInt32(0),
                                                  read.GetString(2),
                                                  read.GetString(1),
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


    /// <summary>
    /// Get an inventory item based off of the Products locations
    /// </summary>
    /// <param name="Product_Code"></param>
    /// <returns></returns>
    public static Inventory Get(string Product_Location)
    {
        using (SqlConnection conn = new SqlConnection())
        {
            conn.ConnectionString = DBConnection.CONNECTION_STRING;
            conn.Open();

            string sql = "SELECT Inventory_Id, Product_Code, Product, Product_Location, On_Hand, Reorder_Level, Reorder_Quantity, On_Order "
                       + "FROM Inventory "
                       + "WHERE Product_Location = @Product_Location";

            SqlCommand command = new SqlCommand(sql, conn);
            command.Parameters.AddWithValue("Product_Location", Product_Location);

            using (SqlDataReader read = command.ExecuteReader())
            {
                if (read.HasRows)
                {
                    read.Read();

                    Inventory inv = new Inventory(read.GetInt32(0),
                                                  read.GetString(2),
                                                  read.GetString(1),
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

    public static Inventory GetWithCode(string Product_Code)
    {
        using (SqlConnection conn = new SqlConnection())
        {
            conn.ConnectionString = DBConnection.CONNECTION_STRING;
            conn.Open();

            string sql = "SELECT Inventory_Id, Product_Code, Product, Product_Location, On_Hand, Reorder_Level, Reorder_Quantity, On_Order "
                       + "FROM Inventory "
                       + "WHERE Product_Code = @Product_Code";

            SqlCommand command = new SqlCommand(sql, conn);
            command.Parameters.AddWithValue("Product_Code", Product_Code);

            using (SqlDataReader read = command.ExecuteReader())
            {
                if (read.HasRows)
                {
                    read.Read();

                    Inventory inv = new Inventory(read.GetInt32(0),
                                                  read.GetString(2),
                                                  read.GetString(1),
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


    public static Inventory GetWithName(string Product)
    {
        using (SqlConnection conn = new SqlConnection())
        {
            conn.ConnectionString = DBConnection.CONNECTION_STRING;
            conn.Open();

            string sql = "SELECT Inventory_Id, Product_Code, Product, Product_Location, On_Hand, Reorder_Level, Reorder_Quantity, On_Order "
                       + "FROM Inventory "
                       + "WHERE Product = @Product";

            SqlCommand command = new SqlCommand(sql, conn);
            command.Parameters.AddWithValue("Product", Product);

            using (SqlDataReader read = command.ExecuteReader())
            {
                if (read.HasRows)
                {
                    read.Read();

                    Inventory inv = new Inventory(read.GetInt32(0),
                                                  read.GetString(2),
                                                  read.GetString(1),
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

            string sql = "SELECT Inventory_Id, Product, Product_Code, Product_Location, On_Hand, Reorder_Level, Reorder_Quantity, On_Order "
                       + "FROM Inventory";

            SqlCommand command = new SqlCommand(sql, conn);
            using (SqlDataReader reader = command.ExecuteReader())
            {
                List<Inventory> invList = new List<Inventory>();

                while (reader.Read())
                {
                    Inventory item = new Inventory(reader.GetInt32(0),
                                                  reader.GetString(2),
                                                  reader.GetString(1),
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
        return this.Product;
	}

   
}

