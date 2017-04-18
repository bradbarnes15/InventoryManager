﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class ProductLocation : DBConnection
{
    private int   Locations_Id     { get; set; }
    public string Product_Location { get; set; }
    public int    Product_Quantity { get; set; }


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


    public void Save()
    {
        using (SqlConnection conn = new SqlConnection())
        {
            conn.ConnectionString = DBConnection.CONNECTION_STRING;
            conn.Open();

            string sql;

            if (Locations_Id == -1)
            {
                sql = "INSERT INTO Product_Locations(Product_Location, Product_Quantity) "
                    + "VALUES(@Product_Location, @Product_Quantity) "
                    + "SELECT CAST (scope_identity() as int)";
            }
            else
            {
                sql = "UPDATE Product_Locations "
                    + "set Product_Location = @Product_Location, Product_Quantity = @Product_Quantity "
                    + "WHERE Locations_Id = @Locations_Id";
            }

            SqlCommand command = new SqlCommand(sql, conn);
            command.Parameters.AddWithValue("Product_Location", Product_Location);
            command.Parameters.AddWithValue("Product_Quantity", Product_Quantity);

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

            string sql = "SELECT Locations_Id, Product_Location, Product_Quantity "
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

            sql = "SELECT Locations_Id, Product_Location, Product_Quantity "
                + "FROM Product_Locations";

            SqlCommand command = new SqlCommand(sql, conn);
            using (SqlDataReader reader = command.ExecuteReader())
            {
                List<ProductLocation> locationList = new List<ProductLocation>();

                while (reader.Read())
                {
                    ProductLocation pl = new ProductLocation(reader.GetInt32(0),
                                                             reader.GetString(1),
                                                             reader.GetInt32(2));
                    locationList.Add(pl);
                }

                return locationList;
            }
        }
    }



}
