using System.Windows;

namespace InventoryManager
{
    /// <summary>
    /// Interaction logic for EmployeeLogIn.xaml
    /// This is form is to test user login and verify password from database
    /// </summary>
    public partial class EmployeeLogIn : Window 
    {
        public EmployeeLogIn()
        {
            InitializeComponent();

        }

        // password verification on user input verses server info
        private void button_Click(object sender, RoutedEventArgs e)
        {
            string userEnteredName = textBox.Text;
            string userEnteredPassword = Employee.Encrypt(textBox1.Text);

            Employee user = new Employee();
            user = DBConnection.VerifyEmployeeLogin(userEnteredName, userEnteredPassword);

            //user.Print();
            if (user != null)
            {
                EmployeeInterface employee = new EmployeeInterface(user);
                employee.Top = 100;
                employee.Left = 400;
                employee.Show();
                this.Close();
            }
            else
            {
                textBox.Text = "Try again";
                textBox1.Text = "invalid password";
            }
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            SecondWindow mainWindow = new SecondWindow();
            mainWindow.Top = 100;
            mainWindow.Left = 400;
            mainWindow.Show();
        }
    }
}
