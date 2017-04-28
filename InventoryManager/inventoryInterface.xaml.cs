using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace InventoryManager 
{
    /// <summary>
    /// Interaction logic for inventoryInterface.xaml
    /// </summary>
    public partial class inventoryInterface : Window
    {

    
        public inventoryInterface()
        {
      
            comboBox.ItemsSource = ProductLocation.GetAll();
            InitializeComponent();
        }

        private void dataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
          
            ProductLocation x = new ProductLocation();
            x = DBConnection.getlocation(textBox.Text);

       //     string dis = "";
            listBox.Items.Clear();

        //    dis += x.Product_Location + x.Product_Code + x.Product_Quantity;
        //    listBox.Items.Add(dis);
            listBox.Items.Add(x.Product_Location);
            listBox.Items.Add(x.Product_Code);
            listBox.Items.Add(x.Product_Quantity);

           
          
        }

        private void listBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
