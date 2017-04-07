﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool
//     Changes to this file will be lost if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

public class OrderStatus 
{
	public virtual string StatusText { get; set; }
    public virtual int OrderStatus_Id { get; set; }
	public virtual DBConnection DBConnection { get; set; }

    public OrderStatus(string statusText)
    {
        this.OrderStatus_Id = -1;
        this.StatusText = statusText;
    }


	public virtual void Save()
	{
        using(SqlConnection conn = new SqlConnection())
        {
            conn.ConnectionString = DBConnection.CONNECTION_STRING;
            conn.Open();

            string sql;

            if (OrderStatus_Id == -1)
            {
                                 //tablename  (column name)        value to add
                sql = "INSERT INTO OrderStatus(Status_Text) VALUES(@Status_Text)"
                    + "SELECT CAST (scope_identity() as int)";
            }
            else
            {
                sql = "UPDATE OrderStatus set Status_Text = @Status_Text where OrderStatus_Id = @OrderStatus_Id";
            }

            SqlCommand command = new SqlCommand(sql, conn);
            command.Parameters.AddWithValue("Status_Text", StatusText);

            if (OrderStatus_Id == -1)
            {
                OrderStatus_Id = (int)command.ExecuteScalar();
            }


        }
	}

}

