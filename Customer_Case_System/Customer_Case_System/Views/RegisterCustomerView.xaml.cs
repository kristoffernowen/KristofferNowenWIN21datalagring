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
            tblockResultCustomer.Text = "";
        }

        private void RegisterCustomer(object sender, RoutedEventArgs e)
        {
            try
            {
                var addressId = _sqlActionUnit.RegisterAddress(tboxStreetName.Text,
                    tboxPostalCode.Text,
                    tboxCity.Text, tboxCountry.Text);
                var customerId =
                    _sqlActionUnit.RegisterCustomerToDatabase(tboxFirstName.Text,
                        tboxLastName.Text, addressId);
                _sqlActionUnit.RegisterContactInfoToDatabase(tboxEmail.Text,
                    tboxPrimaryPhone.Text,
                    tboxSecondaryPhone.Text, customerId);

                tblockResultCustomer.Text = "Kund troligen tillagd, om du inte försökt göra dubletter";
            }
            catch
            {
                tblockResultCustomer.Text =
                    "Du har fyllt i något fel, postnummer t ex har endast fem siffror utan mellanslag";
            }
        }
    }
}
