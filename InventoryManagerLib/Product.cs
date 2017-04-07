using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

public class Product : DBConnection
{
    private int Product_Id { get; set; }
    public string Product_Name { get; set; }
	public string Product_Code { get; set; }
	public bool Discontinue { get; set; }
	public string Category { get; set; }
	public Double List_Price { get; set; }
	public Double Unit_Cost { get; set; }
    

	public Product(string productName, string productCode, string category, double listPrice, double unitCost)
	{
        this.Product_Name = productName;
        this.Product_Code = productCode;
        this.Category     = category;
        this.List_Price   = listPrice;
        this.Unit_Cost    = unitCost;
        this.Discontinue  = false;
        this.Product_Id   = -1;
	}

    private Product(int Product_Id, string productName, string productCode, string category, double listPrice, double unitCost)
    {
        this.Product_Id   = Product_Id;
        this.Product_Name = productName;
        this.Product_Code = productCode;
        this.Category     = category;
        this.List_Price   = listPrice;
        this.Unit_Cost    = unitCost;
        this.Discontinue  = false;
    }


    public void Save()
    {
        using (SqlConnection conn = new SqlConnection())
        {
            conn.ConnectionString = DBConnection.CONNECTION_STRING;
            conn.Open();

            string sql;

            if (Product_Id == -1)
            {
                sql = "INSERT INTO Product(Product_Code, Product_Name, Unit_Cost, List_Price, Discontinue, Category) VALUES(@Product_Code, @Product_Name, @Unit_Cost, @List_Price, @Discontinue, @Category) "
                    + "SELECT CAST (scope_identity() as int)";
            }
            else
            {
                sql = "UPDATE Product set "
                    + "Product_code = @Product_Code, Product_Name = @Product_Name, Unit_Cost = @Unit_Cost, List_Price = @List_Price, Discontinue = @Discontinue, Category = @Category "
                    + "WHERE Product_Id = @Product_Id";
            }

            SqlCommand command = new SqlCommand(sql, conn);
            command.Parameters.AddWithValue("Product_Code", Product_Code);
            command.Parameters.AddWithValue("Product_Name", Product_Name);
            command.Parameters.AddWithValue("Unit_Cost", Unit_Cost);
            command.Parameters.AddWithValue("List_Price", List_Price);
            command.Parameters.AddWithValue("Discontinue", Discontinue);
            command.Parameters.AddWithValue("Category", Category);

            if(Product_Id == -1)
            {
                Product_Id = (int)command.ExecuteScalar();
            }
            else
            {
                command.Parameters.AddWithValue("Product_Id", Product_Id);
                command.ExecuteNonQuery();
            }
        }
    }


    public static Product Get(int Product_Id)
    {
        using (SqlConnection conn = new SqlConnection())
        {
            conn.ConnectionString = DBConnection.CONNECTION_STRING;
            conn.Open();

            string sql = "SELECT Product_Id, Product_Code, Product_Name, Unit_Cost, List_Price, Discontinue, Category "
                       + "FROM Product "
                       + "WHERE Product_Id = @Product_Id";

            SqlCommand command = new SqlCommand(sql, conn);
            command.Parameters.AddWithValue("Product_Id", Product_Id);

            using (SqlDataReader read = command.ExecuteReader())
            {
                if (read.HasRows)
                {
                    read.Read();

                    int productId = read.GetInt32(0);
                    string productName = read.GetString(2);
                    string productCode = read.GetString(1);
                    string category = read.GetString(6);
                    double listPrice = read.GetDouble(4);
                    double unitCost = read.GetDouble(3);

                    Product product = new Product(productId, productName, productCode, category, listPrice, unitCost);
                    return product;
                }
                else
                {
                    return null;
                }
            }
        }
    }


    public static LinkedList<Product> GetAll()
    {
        using (SqlConnection conn = new SqlConnection())
        {
            conn.ConnectionString = DBConnection.CONNECTION_STRING;
            conn.Open();

            string sql;

            sql = "SELECT Product_Id, Product_Code, Product_Name, Unit_Cost, List_Price, Discontinue, Category "
                + "FROM Product";

            SqlCommand command = new SqlCommand(sql, conn);
            using (SqlDataReader reader = command.ExecuteReader())
            {
                LinkedList<Product> productList = new LinkedList<Product>();

                while (reader.Read())
                {
                    Product p = new Product(reader.GetInt32(0), 
                                            reader.GetString(2), 
                                            reader.GetString(1), 
                                            reader.GetString(6),
                                            reader.GetDouble(4),
                                            reader.GetDouble(3)
                                            );

                    productList.AddLast(p);
                }

                return productList;
            }
        }
    }


    public override string ToString()
    {
        string str = "Id: " + Product_Id + ", Code: " + Product_Code + ", Name: " + Product_Name + ", Price:" + List_Price;
        if (Discontinue)
        {
            str += "Discontinued";
        }

        return str;
    }


}

