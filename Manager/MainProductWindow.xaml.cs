using System;
using System.Windows;
using System.Windows.Controls;


namespace InventoryManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Employee k;

        List<Category> categories = Category.GetAll();
        List<ProductLocation> locations = ProductLocation.GetAllEmpty();

        public MainWindow(Employee x)
        {
            InitializeComponent();

            listBox.ItemsSource = Product.GetAll();
            
            foreach(Category item in categories)
            {
                category_comboBox.Items.Add(item);
            }
            foreach(ProductLocation item in locations)
            {
                Location_comboBox.Items.Add(item);
            }

            //This shows which employee is logged in
            k = x;
        }

        private void Add_Product_button_Click(object sender, RoutedEventArgs e)
        {
            string product_Code = Product_Code_Textbox.Text.ToString();
            string product_Name = Product_Name_textBox.Text.ToString();

            double list_price, unit_price;
            bool listPrice, unitPrice, reorderLevel, reorderQuant, onHand;
            int reorder_level, reorder_quant, on_Hand;

            CheckTextBoxes(out list_price, out listPrice, out unit_price, out unitPrice, out reorder_level, out reorderLevel, out reorder_quant, out reorderQuant, out on_Hand, out onHand);

            //Ensure all fields have actually been filled out
            if (listPrice && unitPrice && reorderLevel && reorderQuant && onHand && product_Code.Length >= 4 && product_Name.Length >= 1 && category_comboBox.SelectedIndex >= 0)
            {
                //Create and Add the product to the database
                string category = category_comboBox.Text.ToString();
                Product product = new Product(product_Name, product_Code, category, list_price, unit_price);

                string location = Location_comboBox.Text.ToString();
                Inventory inventoryitem = new Inventory(product_Name, location, product_Code, on_Hand, reorder_level, reorder_quant);

                ProductLocation pl = (ProductLocation)Location_comboBox.SelectedItem;
                ProductLocation.ChangeItemAtLocation(pl.Product_Location, product_Code, on_Hand);

                product.Save();
                inventoryitem.Save();

                //Reset all Textboxes to blank;
                ResetBoxesToBlank();
                listBox.ItemsSource = Product.GetAll(); //refresh the listbox items
                List<ProductLocation> locations = ProductLocation.GetAllEmpty();
                Location_comboBox.Items.Clear();
                foreach (ProductLocation item in locations)
                {
                    Location_comboBox.Items.Add(item);
                }
            }

            

        }

        private void ResetBoxesToBlank()
        {
            Product_Code_Textbox.Text    = null;
            Product_Name_textBox.Text    = null;
            List_Price_textBox.Text      = null;
            Unit_Price_textBox.Text      = null;
            ReorderLevel_textBox.Text    = null;
            ReorderQuantity_textBox.Text = null;
            OnHand_textBox.Text          = null;
            Location_textBox.Text        = null;
            category_comboBox.SelectedIndex = -1;
            Location_comboBox.SelectedIndex = -1;
        }

        private void CheckTextBoxes(out double list_price, out bool listPrice, out double unit_price, out bool unitPrice, out int reorder_level, out bool reorderLevel, out int reorder_quant, out bool reorderQuant, out int on_Hand, out bool onHand)
        {
            //Check the Product code
            if(Product_Code_Textbox.Text.Length < 4)
            {
                Product_Code_Textbox.Background = new SolidColorBrush(Colors.Red);
            }
            else { Product_Code_Textbox.Background = new SolidColorBrush(Colors.White); }

            //Check the product name
            if(Product_Name_textBox.Text.Length < 1)
            {
                Product_Name_textBox.Background = new SolidColorBrush(Colors.Red);
            }
            else { Product_Name_textBox.Background = new SolidColorBrush(Colors.White); }

            //Check the listprice
            listPrice = false;
            if (!double.TryParse(List_Price_textBox.Text, out list_price))
            {
                List_Price_textBox.Text = "Invalid Price";
                List_Price_textBox.Background = new SolidColorBrush(Colors.Red);
            }
            else { List_Price_textBox.Background = new SolidColorBrush(Colors.White); listPrice = true; }

            //Check the unit price
            unitPrice = false;
            if (!double.TryParse(Unit_Price_textBox.Text, out unit_price))
            {
                Unit_Price_textBox.Text = "Invalid Price";
                Unit_Price_textBox.Background = new SolidColorBrush(Colors.Red);
            }
            else { Unit_Price_textBox.Background = new SolidColorBrush(Colors.White); unitPrice = true; }

            //Check the reorder level
            reorderLevel = false;
            if (!int.TryParse(ReorderLevel_textBox.Text, out reorder_level))
            {
                ReorderLevel_textBox.Text = "Invalid Quantity";
                ReorderLevel_textBox.Background = new SolidColorBrush(Colors.Red);
            }
            else { ReorderLevel_textBox.Background = new SolidColorBrush(Colors.White); reorderLevel = true; }

            //Check the reorder quantity
            reorderQuant = false;
            if (!int.TryParse(ReorderQuantity_textBox.Text, out reorder_quant))
            {
                ReorderQuantity_textBox.Text = "Invalid Quantity";
                ReorderQuantity_textBox.Background = new SolidColorBrush(Colors.Red);
            }
            else { ReorderQuantity_textBox.Background = new SolidColorBrush(Colors.White); reorderQuant = true; }

            //Check the On hand amount
            onHand = false;
            if (!int.TryParse(OnHand_textBox.Text, out on_Hand))
            {
                OnHand_textBox.Text = "Invalid Quantity";
                OnHand_textBox.Background = new SolidColorBrush(Colors.Red);
            }
            else { OnHand_textBox.Background = new SolidColorBrush(Colors.White); onHand = true; }

            //Check the category combobox
            if (category_comboBox.SelectedIndex < 0)
            {
                category_comboBox.Background = new SolidColorBrush(Colors.Red);
            }
            else { category_comboBox.Background = new SolidColorBrush(Colors.White); }
        }



        //Update the selected product
        private void Update_Product_button_Click(object sender, RoutedEventArgs e)
        {
            //Check all of the text/combo box fields
            string product_Code = Product_Code_Textbox.Text.ToString();
            string product_Name = Product_Name_textBox.Text.ToString();
            double list_price, unit_price;
            bool listPrice, unitPrice, reorderLevel, reorderQuant, onHand;
            int reorder_level, reorder_quant, on_Hand;
            CheckTextBoxes(out list_price, out listPrice, out unit_price, out unitPrice, out reorder_level, out reorderLevel, out reorder_quant, out reorderQuant, out on_Hand, out onHand);


            if (listPrice && unitPrice && reorderLevel && reorderQuant && onHand && product_Code.Length > 1 && product_Name.Length > 1)
            {
                Product product = (Product)listBox.SelectedItem;
                Inventory inventory = Inventory.GetWithCode(product.Product_Code);

                string category = category_comboBox.Text.ToString();

                Product.ChangeProductCategory(product.Product_Id, category);
                Product.UpdateListPrice(product.Product_Id, list_price);

                Inventory.setFiltersToOrder(product.Product_Id, reorder_level, reorder_quant);
                inventory.ModifyItemStock(on_Hand);

                //Re-enable the textboxes that can't be updated in case a new product is to be added
                Product_Code_Textbox.IsEnabled = true;
                Product_Name_textBox.IsEnabled = true;
                Unit_Price_textBox.IsEnabled   = true;

                //reset/update all fields
                listBox.ItemsSource = Product.GetAll();
                Disc_Product_button.IsEnabled   = false;
                Update_Product_button.IsEnabled = false;
                Add_Product_button.IsEnabled    = true;
                Location_comboBox.IsEnabled     = true;

                ResetBoxesToBlank();
            }
        }




        private void listBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((Product)listBox.SelectedItem != null)
            {
                Product product = (Product)listBox.SelectedItem;

                if (Inventory.GetWithCode(product.Product_Code) != null)
                {
                    Inventory inventory = Inventory.GetWithCode(product.Product_Code);

                    //Set all textbox values to the corresponding values of that product so it can be updated
                    Product_Code_Textbox.Text    = product.Product_Code;
                    Product_Name_textBox.Text    = product.Product_Name;
                    List_Price_textBox.Text      = product.List_Price.ToString();
                    Unit_Price_textBox.Text      = product.Unit_Cost.ToString();
                    ReorderLevel_textBox.Text    = inventory.Reorder_Level.ToString();
                    ReorderQuantity_textBox.Text = inventory.Reorder_Quantity.ToString();
                    OnHand_textBox.Text          = inventory.On_Hand.ToString();
                    Location_textBox.Text        = inventory.Product_Location;

                    //Disable the textBoxes that can't be modified
                    Product_Code_Textbox.IsEnabled = false;
                    Product_Name_textBox.IsEnabled = false;
                    Unit_Price_textBox.IsEnabled   = false;

                    //Find which category the item has and set the combobox to show it
                    int index = 0;
                    for(int i = 0; i < categories.Count; i++)
                    {
                        if (categories[i].Category_Text == product.Category)
                        {
                            index = i;
                        }
                    }
                    category_comboBox.SelectedIndex = index;


                    /*---Not sure that this is possible---
                     * --Regardless, I'm out of time to try--
                     * 
                    //Because the combobox is filled with empty locations, 
                    //we need to add the location this item is at befeore searching for it
                    Category currLocation = Category.Get(inventory.Product_Location);
                    Location_comboBox.Items.Add(currLocation);
                    for(int i = 0; i < locations.Count; i++)
                    {
                        if(locations[i].Product_Location == inventory.Product_Location)
                        {
                            index = i;
                        }
                    }*/

                    Location_comboBox.Text = inventory.Product_Location;
                    Location_comboBox.IsEnabled = false;

                    //Enable/disable the necessary buttons
                    //-Discontinue and Update need to be clickable
                    //-Add can not be clickable 
                    Disc_Product_button.IsEnabled   = true;
                    Update_Product_button.IsEnabled = true;
                    Add_Product_button.IsEnabled    = false;
                }
            }
            

            
        }
        
        
        

        private void Disc_Product_button_Click(object sender, RoutedEventArgs e)
        {
            Product item = (Product)listBox.SelectedItem;
            item.DiscontinueItem();
            listBox.ItemsSource = Product.GetAll();

            //Set the proper button enablings
            Disc_Product_button.IsEnabled   = false;
            Update_Product_button.IsEnabled = false;
            Add_Product_button.IsEnabled    = true;
            Location_comboBox.IsEnabled     = true;

            //Re-enable the textboxes that can't be modified
            Product_Code_Textbox.IsEnabled = true;
            Product_Name_textBox.IsEnabled = true;
            Unit_Price_textBox.IsEnabled   = true;

            ResetBoxesToBlank();
        }

        //Back Button - returns to previous menu
        private void button_Click(object sender, RoutedEventArgs e)
        {
            inventoryInterface x = new inventoryInterface(k);
            x.Top = 100;
            x.Left = 400;
            x.Show();
            this.Close();

        }






        private void category_comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }



        /*
        private void button_Click_1(object sender, RoutedEventArgs e)
        {
            int x = 101;
            for (int y = 0; y < 100; y++)
            {

                string a = "A";
                // string g = x.ToString();
                string b = a + x.ToString();
                Console.WriteLine(b);
                ProductLocation t = new ProductLocation(b, "Empty", 0);
                   t.Save();
                x = x + 1;
            }
        }*/





    }
}
