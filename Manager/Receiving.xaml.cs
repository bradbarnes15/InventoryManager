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
            k = x;
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            EmployeeInterface window = new EmployeeInterface(k);
            this.Close();
            window.Top = 100;
            window.Left = 400;
            window.Show();
        }

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
