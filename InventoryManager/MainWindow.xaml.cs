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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace InventoryManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            //listBox.ItemsSource = Category.GetAll();
            comboBox.ItemsSource = PurchaseOrder.GetAll();
            
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
            PurchaseOrder order = (PurchaseOrder)comboBox.SelectedItem;

            listBox.Items.Clear();

            listBox.ItemsSource = PurchaseOrderDetails.GetAllAt(order.PurchaseOrders_Id);
            
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
