using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
            string userEnteredPassword1 = Employee.Encrypt(textBox1.Text);

            Employee b = new Employee();
            b = DBConnection.get(userEnteredName, userEnteredPassword);
            b.ToString();
            if (b != null)
            {
                b.Print();
            }
            if (Employee.Decrypt(Employee.getPass(b)) == userEnteredPassword1)
            {
                Console.WriteLine("YES");
            }
        }
        /*
        private void button_Click(object sender, RoutedEventArgs e)
        {
            Employee a = new Employee(textBox.Text,
                                        textBox1.Text,
                                        textBox3.Text,
                                        textBox4.Text);
            a.Print();
            Console.WriteLine(a);
            a.addEmployeeToDB();
        }
        
        public void delete(String tableName, String fieldName, int pkValue)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = DBTable.CONNECTION_STR;
                conn.Open();

                String sql;
                sql = "delete from [" + tableName + "] where [" + fieldName + "] = @id";

                SqlCommand command = new SqlCommand(sql, conn);
                command.Parameters.AddWithValue("id", pkValue);

                command.ExecuteNonQuery();

            }
        }
        */
    }
}
