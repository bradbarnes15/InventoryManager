using InventoryManager;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace Manager
{
    /// <summary>
    /// Interaction logic for CreateOrder.xaml
    /// </summary>
    public partial class CreateOrder : Window
    {
        List<Product> list = new List<Product>();
        List<MyItem> list1 = new List<MyItem>();
        double totalForOrder = 0;
        Employee k;
        
        public CreateOrder(Employee x)
        {
            InitializeComponent();
            comboBox.ItemsSource = Product.GetAll();
            k = x;
            button1.IsEnabled = false;

            // Add columns
            var gridView = new GridView();
            this.listView.View = gridView;
            gridView.Columns.Add(new GridViewColumn 
            {
                Width = 75,
                Header = "Product",
                DisplayMemberBinding = new Binding("Product")
                
            });
            gridView.Columns.Add(new GridViewColumn
            {
                Width = 75,
                Header = "Quanitity",
                DisplayMemberBinding = new Binding("Quanitity")
            });
            gridView.Columns.Add(new GridViewColumn
            {
                Width = 75,
                Header = "Price",
                DisplayMemberBinding = new Binding("Price")
            });
            gridView.Columns.Add(new GridViewColumn
            {
                Width=75,
                Header = "Total",
                DisplayMemberBinding = new Binding("Total")
            });

        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            Receiving window = new Receiving(k);
            this.Close();
            window.Top = 100;
            window.Left = 400;
            window.Show();
        }

        public class MyItem 
        {
           // List<MyItem> list1 = new List<MyItem>();
            public string Product { get; set; }

            public int Quanitity { get; set; }

            public double Price { get; set; }

            public double Total { get; set; }
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            string value = comboBox.SelectedItem.ToString();
            Product x = (Product)comboBox.SelectedItem;

            //Console.WriteLine(x.Product_Quantity);
            int newValue;
            if (Int32.TryParse(textBox.Text, out newValue))
            {
               // listBox.Items.Add("Product : " + x.Product_Name+ " "  + newValue + " $" + x.List_Price + " " + (newValue*x.List_Price) );
            }
            totalForOrder +=  (newValue* x.List_Price);
            textBox1.Text = totalForOrder.ToString();

            //  listView.Items.Add("Product : " + x.Product_Name + " " + newValue + " $" + x.List_Price + " " + (newValue * x.List_Price));
            //listView.Items[count] = ("Product : " + x.Product_Name + " " + newValue + " $" + x.List_Price + " " + (newValue * x.List_Price) );

            // used to fill listview
            listView.Items.Add(new MyItem { Product = x.Product_Name, Quanitity = newValue, Price = x.List_Price, Total = (Convert.ToDouble(newValue) * x.List_Price) });
           
            MyItem q = new MyItem();
            q.Product = x.Product_Name; q.Quanitity = newValue; q.Price = x.List_Price; q.Total = (Convert.ToDouble(newValue) * x.List_Price);
            list1.Add(q);
        }

        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           if(textBox.Text != "")
                button1.IsEnabled = true;
        }

        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {

            // public PurchaseOrder(DateTime Order_Date, string Created_By, DateTime Created_Date, double Shipping_Fee, double Tax, DateTime Payment_Date, double Payment_Amount, double Order_Subtotal, double Order_Total, DateTime Date_Received, string Status)
            PurchaseOrder order = new PurchaseOrder( DateTime.Parse("2017-05-01") , k.firstName , DateTime.Parse("2017-05-01"),20.00,.09, DateTime.Parse("2017-05-01"), totalForOrder,totalForOrder,totalForOrder, DateTime.Parse("2017-05-01"), "new" );
            order.Save();
            foreach (MyItem c in list1)
            {
                PurchaseOrderDetails item = new PurchaseOrderDetails(order.PurchaseOrders_Id,c.Product,c.Quanitity,c.Price,(c.Price*c.Quanitity));
                item.Save();
            }
        }
    }
}
