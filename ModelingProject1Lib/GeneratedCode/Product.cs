﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool
//     Changes to this file will be lost if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Product : DBConnection
{
	private string productName
	{
		get;
		set;
	}

	private string productCode
	{
		get;
		set;
	}

	private bool discontine
	{
		get;
		set;
	}

	private string category
	{
		get;
		set;
	}

	private int productId
	{
		get;
		set;
	}

	private Double listPrice
	{
		get;
		set;
	}

	private Double unitCost
	{
		get;
		set;
	}

	public virtual void ToString()
	{
		throw new System.NotImplementedException();
	}

	public Product()
	{
	}

}

