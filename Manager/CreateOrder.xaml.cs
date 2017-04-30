using InventoryManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Manager
{
    /// <summary>
    /// Interaction logic for CreateOrder.xaml
    /// </summary>
    public partial class CreateOrder : Window
    {
        List<Product> list = new List<Product>();
        double totalForOrder = 0;
        Employee k;
        
        public CreateOrder(Employee x)
        {
            InitializeComponent();
            comboBox.ItemsSource = Product.GetAll();
            k = x;

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
                listBox.Items.Add("Product : " + x.Product_Name+ " "  + newValue + " $" + x.List_Price + " " + (newValue*x.List_Price) );
            }
            totalForOrder +=  (newValue* x.List_Price);
            textBox1.Text = totalForOrder.ToString();

            //  listView.Items.Add("Product : " + x.Product_Name + " " + newValue + " $" + x.List_Price + " " + (newValue * x.List_Price));
            //listView.Items[count] = ("Product : " + x.Product_Name + " " + newValue + " $" + x.List_Price + " " + (newValue * x.List_Price) );
            //count += 1;

            listView.Items.Add(new MyItem { Product = x.Product_Name, Quanitity = newValue, Price = x.List_Price, Total = (Convert.ToDouble(newValue) * x.List_Price) });

            /*
            if ()
            {
                listBox.Items.Clear();
          
                listBox.Items.Add("Product location : " + x.Product_Location);
                listBox.Items.Add("Product Code     : " + x.Product_Code);
                listBox.Items.Add("Product Quantity : " + (x.Product_Quantity));

                textBox.IsEnabled = false;
             
            }
            else
            {
                Inventory item = Inventory.Get(value);

                listBox.Items.Clear();
                listBox.Items.Add("Product : " + item.Product);
                listBox.Items.Add("Product Code : " + item.Product_Code);
                listBox.Items.Add("On Hand : " + item.On_Hand);
                listBox.Items.Add("On Order : " + item.On_Order);
                listBox.Items.Add("Reorder Level : " + item.Reorder_Level);
                listBox.Items.Add("Reorder Quantity : " + item.Reorder_Quantity);

                textBox.IsEnabled = true;
            }

            */
        }

        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            button.IsEnabled = true;
        }

        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
