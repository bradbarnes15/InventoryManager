﻿using System;
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

        public Employee k;
        public EmployeeInterface()
        {
            InitializeComponent();
            displayTime();
   
        }
        public EmployeeInterface(Employee x)
        {
            InitializeComponent();
            displayTime(x);
            k = x;
            

        }

        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           // String s = comboBox1.Text;

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
        private void displayTime(Employee x)
        {
            //Employee user = new Employee("sam", "smith");
            string display = "" + x.firstName + "" + x.lastName;
           // Console.WriteLine(display);
            string two;
            two = DateTime.Now.ToShortTimeString();
            Console.WriteLine(two);
            display = display + " Logged in @: " + two;
            label.Content = display;
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            EmployeeLogIn window = new EmployeeLogIn();
            this.Close();
            window.Top = 100;
            window.Left = 400;
            window.Show();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            String s = comboBox.Text;
            if( s == "Inventory")
            {
                inventoryInterface windowINV = new inventoryInterface(k);
                this.Close();
                windowINV.Top = 100;
                windowINV.Left = 400;
                windowINV.Show();
             }
            if (s == "Receving")
            {
                Receiving windowINV = new Receiving(k);
                this.Close();
                windowINV.Top = 100;
                windowINV.Left = 400;
                windowINV.Show();
            }
            if (s == "OrderPicking")
            {
                orderpicking windowINV = new orderpicking(k);
                this.Close();
                windowINV.Top = 100;
                windowINV.Left = 400;
                windowINV.Show();
            }
        }

        private void ComboBoxItem_Selected(object sender, RoutedEventArgs e)
        {

        }
    }
}
