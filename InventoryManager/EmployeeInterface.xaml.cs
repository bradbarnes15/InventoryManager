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
    /// Interaction logic for EmployeeInterface.xaml
    /// Started Employee Interface
    /// Add job selection menu
    /// label that show current user and login time 
    /// </summary>
    public partial class EmployeeInterface : Window
    {
        public EmployeeInterface()
        {
            InitializeComponent();
            displayTime();
   
        }

        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        private void displayTime()
        {
            Employee user = new Employee("sam","smith");
            string display = "" + Employee.getFnLn(user);
            Console.WriteLine(display);
            string two;
            two = DateTime.Now.ToShortTimeString();
            Console.WriteLine(two);
            display =  display+ " Logged in @: " + two;
            label.Content = display;
        }
    }
}
