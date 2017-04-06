using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Inventory : DBConnection
{
    private string Product { get; set; }
    private int On_Hand { get; set; } 
	private int Inventory_Id { get; set; }
	private int Reorder_Level { get; set; }
	private int Reorder_Quantity { get; set; }
    private int On_Order { get; set; }



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

