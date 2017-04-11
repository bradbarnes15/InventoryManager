using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Inventory : DBConnection
{
    private string Product { get; set; }
    private string Product_Location { get; set; }
    private int On_Hand { get; set; } 
	private int Inventory_Id { get; set; }
	private int Reorder_Level { get; set; }
	private int Reorder_Quantity { get; set; }
    private int On_Order { get; set; }


    public Inventory(string Product,string product_Location, int On_Hand, int Reorder_Level, int Reorder_Quantity)
    {
        this.Product = Product;
        this.Product_Location = product_Location;
        this.On_Hand = On_Hand;
        this.Reorder_Level = Reorder_Level;
        this.Reorder_Quantity = Reorder_Quantity;
        On_Order = 0;
    }
    


	public override string ToString()
	{
		throw new System.NotImplementedException();
	}

	public virtual void AddNewItem()
	{
		throw new System.NotImplementedException();
	}

	public virtual void ModifyItemDetails()
	{
		throw new System.NotImplementedException();
	}

	public virtual void ModifyItemStock()
	{
		throw new System.NotImplementedException();
	}

	public virtual void RemoveItem()
	{
		throw new System.NotImplementedException();
	}

	public virtual void setFiltersToOrder()
	{
		throw new System.NotImplementedException();
	}

}

