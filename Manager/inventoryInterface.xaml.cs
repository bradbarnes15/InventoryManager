using System;
using System.Windows;
using System.Windows.Controls;

namespace InventoryManager
{
    /// <summary>
    /// Interaction logic for inventoryInterface.xaml
    /// </summary>
    public partial class inventoryInterface : Window
    {

        Employee k;
        public inventoryInterface()
        {
            InitializeComponent();
            comboBox.ItemsSource = ProductLocation.GetAll();
        }
        public inventoryInterface(Employee x)
        {
            InitializeComponent();
            comboBox.ItemsSource = ProductLocation.GetAll();
            k = x;
        }

        private void dataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
          
        }

        private void listBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string value = comboBox.SelectedItem.ToString();
            ProductLocation x = ProductLocation.Get(value);

            Console.WriteLine(x.Product_Quantity);

            if (x.Product_Code == "Empty" )
            {
                listBox.Items.Clear();
                listBox.Items.Add("Product location : " + x.Product_Location);
                listBox.Items.Add("Product Code     : " + x.Product_Code);
                listBox.Items.Add("Product Quantity : " + (x.Product_Quantity));

                textBox.IsEnabled = false;
                button2.IsEnabled = false;
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
                button2.IsEnabled = true;
            }

        }

        private void textBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            //Get the selected item
            string value = comboBox.SelectedItem.ToString();
            Inventory item = Inventory.Get(value);

            //update the item quantity
            int newValue;
            if(Int32.TryParse(textBox.Text, out newValue))
            {
                item.ModifyItemStock(newValue);
            }

            //update the listbox
            listBox.Items.Clear();
            listBox.Items.Add("Product : " + item.Product);
            listBox.Items.Add("Product Code : " + item.Product_Code);
            listBox.Items.Add("On Hand : " + item.On_Hand);
            listBox.Items.Add("On Order : " + item.On_Order);
            listBox.Items.Add("Reorder Level : " + item.Reorder_Level);
            listBox.Items.Add("Reorder Quantity : " + item.Reorder_Quantity);
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            EmployeeInterface window = new EmployeeInterface (k);
            this.Close();
            window.Top = 100;
            window.Left = 400;
            window.Show();
        }

        private void button_Click_1(object sender, RoutedEventArgs e)
        {
            MainWindow x = new MainWindow(k);
            x.Top = 100;
            x.Left = 400;
            x.Show();
            this.Close();
        }
    }
}
