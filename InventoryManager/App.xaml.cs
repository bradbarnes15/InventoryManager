using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace InventoryManager
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        /* add windows to startup to test code
        *  secondwindow is to create employee and add to database
        *  employee login is to test the log in system which will let employee / manager into the system
        *  employee interface is where employee will select which job duty to preform
        */
        void App_Startup(object sender, StartupEventArgs e)
        {
            /*
            SecondWindow mainWindow = new SecondWindow();
            mainWindow.Top = 100;
            mainWindow.Left = 400;
            mainWindow.Show();
          
            EmployeeLogIn window = new EmployeeLogIn();
            window.Top = 100;
            window.Left = 400;
            window.Show();
         */
            EmployeeInterface employeewindow = new EmployeeInterface();
            employeewindow.Top = 100;
            employeewindow.Left = 500;
            employeewindow.Show();

        }

    }
}
