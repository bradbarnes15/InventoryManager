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

namespace InventoryManager
{
    /// <summary>
    /// Interaction logic for orderpicking.xaml
    /// </summary>
    public partial class orderpicking : Window
    {
        Employee k;
        public orderpicking(Employee x)
        {
            InitializeComponent();

            orders_listBox.ItemsSource = Orders.GetAll();

            //this shows the employee that is logged in
            k = x;
        }



        //Return to the previous menu
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            EmployeeInterface window = new EmployeeInterface(k);
            this.Close();
            window.Top = 100;
            window.Left = 400;
            window.Show();
        }



        private void orders_listBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((Orders)orders_listBox.SelectedItem != null)
            {
                Orders order = (Orders)orders_listBox.SelectedItem;

                if(order.Status.ToUpper() == "COMPLETED")
                {
                    complete_button.IsEnabled = false;
                }
                else
                {
                    complete_button.IsEnabled = true;
                }

                //orderDetails_listBox.ItemsSource = OrderDetails.GetAllAt(order.Order_Id);
                foreach(OrderDetails item in OrderDetails.GetAllAt(order.Order_Id))
                {
                    orderDetails_listBox.Items.Add(item);
                }
            }
        }

        private void orderDetails_listBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void complete_button_Click(object sender, RoutedEventArgs e)
        {
            Orders order = (Orders)orders_listBox.SelectedItem;

            order.CompleteOrder();

            orders_listBox.ItemsSource = Orders.GetAll();
            orderDetails_listBox.Items.Clear();
            complete_button.IsEnabled = false;
        }
    }
}
