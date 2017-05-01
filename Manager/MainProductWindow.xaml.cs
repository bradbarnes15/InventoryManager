using System;
using System.Windows;
using System.Windows.Controls;

namespace InventoryManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Employee k;
        public MainWindow(Employee x)
        {
            InitializeComponent();

            //listBox.ItemsSource = Category.GetAll();
            comboBox.ItemsSource = ProductLocation.GetAll();
            k = x;
        }

        private void Add_Product_button_Click(object sender, RoutedEventArgs e)
        {
            double listPrice;

            listPrice = (double)Convert.ToDouble(List_Price_textBox.Text);

            Product product = new Product(Product_Name_textBox.Text, Product_Code_textBox.Text, "blank",listPrice, 5.0);

            product.Save();
        }

        private void Update_Product_button_Click(object sender, RoutedEventArgs e)
        {
            int productID = (int)Convert.ToInt32(Product_Id_Textbox.Text);

            double listPrice = (double)Convert.ToDouble(List_Price_textBox.Text);

            Product.UpdateListPrice(productID, listPrice);

            Product.ChangeProductCategory(productID, comboBox.SelectedValue.ToString()); // comboBox xaml must have SelectedValuePath = "Content" in order to work
        }

        private void listBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            listBox.Items.Clear();

            string value = comboBox.SelectedItem.ToString();

            ProductLocation location = ProductLocation.Get(value);

            string str = "Product: " + location.Product_Code;

            listBox.Items.Add(str);
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            inventoryInterface x = new inventoryInterface(k);
            x.Top = 100;
            x.Left = 400;
            x.Show();
            this.Close();

        }




        /*
        private void button_Click_1(object sender, RoutedEventArgs e)
        {
            int x = 101;
            for (int y = 0; y < 100; y++)
            {

                string a = "A";
                // string g = x.ToString();
                string b = a + x.ToString();
                Console.WriteLine(b);
                ProductLocation t = new ProductLocation(b, "Empty", 0);
                   t.Save();
                x = x + 1;
            }
        }*/





    }
}
