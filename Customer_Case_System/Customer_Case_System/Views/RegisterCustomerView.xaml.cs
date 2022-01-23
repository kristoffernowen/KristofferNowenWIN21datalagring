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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Customer_Case_System.DatabaseActionUnits;
using Customer_Case_System.Models;

namespace Customer_Case_System.Views
{
    /// <summary>
    /// Interaction logic for RegisterCustomerView.xaml
    /// </summary>
    public partial class RegisterCustomerView : UserControl
    {
        private SqlActionUnit _sqlActionUnit = new SqlActionUnit();
        public RegisterCustomerView()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var addressExists =_sqlActionUnit.RegisterAddress(tboxStreetName.Text, tboxPostalCode.Text, tboxCity.Text, tboxCountry.Text);
            // if (addressExists)
            //     tblockStreetName.Text = "Adressen fanns redan";
            // else
            // {
            //     tblockStreetName.Text = "Adressen lades till";
            // }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
           var addressToBeRead = _sqlActionUnit.ReadAddressFromDatabase(Convert.ToInt32(tboxReadAddressId.Text));
           tblockStreetName.Text = addressToBeRead.StreetName;
           tblockPostalCode.Text = addressToBeRead.PostalCode;
           tblockCity.Text = addressToBeRead.City;
           tblockCountry.Text = addressToBeRead.Country;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            var address = new Address
            {
                StreetName = tboxStreetName.Text, PostalCode = tboxPostalCode.Text, City = tboxCity.Text,
                Country = tboxCountry.Text
            };
            _sqlActionUnit.UpdateAddress(Convert.ToInt32(tboxReadAddressId.Text), address);
        }

        private void RegisterCustomer(object sender, RoutedEventArgs e)
        {
            var addressId = _sqlActionUnit.RegisterAddress(tboxStreetName.Text, tboxPostalCode.Text, tboxCity.Text, tboxCountry.Text);
            var customerId = _sqlActionUnit.RegisterCustomerToDatabase(tboxFirstName.Text, tboxLastName.Text, addressId);
            _sqlActionUnit.RegisterContactInfoToDatabase(tboxEmail.Text, tboxPrimaryPhone.Text, tboxSecondaryPhone.Text, customerId);
        }

        
    }
}
