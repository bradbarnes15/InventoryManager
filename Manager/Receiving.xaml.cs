using Manager;
using System.Windows;

namespace InventoryManager
{
    /// <summary>
    /// Interaction logic for Receiving.xaml
    /// </summary>
    public partial class Receiving : Window
    {
        Employee k;
        public Receiving(Employee x)
        {
            InitializeComponent();

            orders_listBox.ItemsSource = PurchaseOrder.GetAll();

            //This is the employee that is logged in
            k = x;
        }



        private void orders_listBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if((PurchaseOrder)orders_listBox.SelectedItem != null)
            {
                PurchaseOrder order = (PurchaseOrder)orders_listBox.SelectedItem;

                //if the order has already been completed, you cannot complete it again.
                if(order.Status.ToUpper() == "COMPLETED")
                {
                    completeOrder_button.IsEnabled = false;
                }
                else { completeOrder_button.IsEnabled = true; }

                foreach(PurchaseOrderDetails item in PurchaseOrderDetails.GetAllAt(order.PurchaseOrders_Id))
                {
                    orderDetails_listBox.Items.Add(item);
                }
            }
        }


        private void completeOrder_button_Click(object sender, RoutedEventArgs e)
        {
            PurchaseOrder order = (PurchaseOrder)orders_listBox.SelectedItem;

            order.CompleteOrder();

            orders_listBox.ItemsSource = PurchaseOrder.GetAll();
            orderDetails_listBox.Items.Clear();
            completeOrder_button.IsEnabled = false;
        }

        //Return to previous menu
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            EmployeeInterface window = new EmployeeInterface(k);
            this.Close();
            window.Top = 100;
            window.Left = 400;
            window.Show();
        }

        // GO to create order menu
        private void button2_Click(object sender, RoutedEventArgs e)
        {
            CreateOrder x = new CreateOrder(k);
            x.Top = 100;
            x.Left = 400;
            x.Show();
            this.Close();
        }

    }
}
