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
      
          
            InitializeComponent();
            comboBox.ItemsSource = ProductLocation.GetAll();
        }

        private void dataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
          
     //       ProductLocation x = new ProductLocation();
     //       x = DBConnection.getlocation(textBox.Text);
//
       //     string dis = "";
     //       listBox.Items.Clear();

        //    dis += x.Product_Location + x.Product_Code + x.Product_Quantity;
        //    listBox.Items.Add(dis);
        //    listBox.Items.Add(x.Product_Location);
       //     listBox.Items.Add(x.Product_Code);
      //      listBox.Items.Add(x.Product_Quantity);

           
          
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
          //  x = DBConnection.getlocation(comboBox.SelectionBoxItem.ToString());

            //     string dis = "";
            listBox.Items.Clear();

            //    dis += x.Product_Location + x.Product_Code + x.Product_Quantity;
            //    listBox.Items.Add(dis);
            listBox.Items.Add("Product location : " + x.Product_Location);
            listBox.Items.Add("Product Code     : " + x.Product_Code);
            listBox.Items.Add("Product Quantity : " + x.Product_Quantity);

        }

        private void textBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {

            string value = comboBox.SelectedItem.ToString();
            ProductLocation x = ProductLocation.Get(value);
            //  x = DBConnection.getlocation(comboBox.SelectionBoxItem.ToString());

            //     string dis = "";
            listBox.Items.Clear();

            //    dis += x.Product_Location + x.Product_Code + x.Product_Quantity;
            //    listBox.Items.Add(dis);
            listBox.Items.Add("Product location : " + x.Product_Location);
            listBox.Items.Add("Product Code     : " + x.Product_Code);
            listBox.Items.Add("Product Quantity : " + (x.Product_Quantity + textBox.Text));

        }
    }
}
