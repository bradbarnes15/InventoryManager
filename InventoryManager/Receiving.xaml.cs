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
    }
}
