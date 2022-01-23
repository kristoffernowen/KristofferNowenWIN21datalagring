using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using Customer_Case_System.Data;
using Customer_Case_System.DatabaseActionUnits;
using Customer_Case_System.Models;

namespace Customer_Case_System.Views
{
    /// <summary>
    /// Interaction logic for DisplayCustomersView.xaml
    /// </summary>
    public partial class DisplayCustomersView : UserControl
    {
        private SqlActionUnit _sqlActionUnit = new();
        private ObservableCollection<DisplayCustomer> _displayCustomers;
        private List<DisplayCustomer> displayCustomers;
        private ObservableCollection<Customer> _customers;

        public DisplayCustomersView()
        {
            InitializeComponent();
            
        }

        private void btnDisplayAddresses_Click(object sender, RoutedEventArgs e)
        {
            var addressesToDisplayInList = _sqlActionUnit.ReadAddressesFromDatabase().ToList();

            lvAddresses.ItemsSource = addressesToDisplayInList;
        }

        // public void DisplayAddresses()
        // {
        //     var addressesToDisplayInList = _sqlActionUnit.ReadAddressesFromDatabase().ToList();
        //
        //     lvAddresses.ItemsSource = addressesToDisplayInList;
        // }
        // private void btnDelete_Click(object sender, RoutedEventArgs e)
        // {
        //     var obj = (Button)sender;
        //     var item = (Address)obj.DataContext;
        //
        //     _sqlActionUnit.DeleteAddress(item.Id);
        //     DisplayAddresses();
        // }

        

        private void btnDisplayCustomers_Click(object sender, RoutedEventArgs e)
        {
            // var customersToDisplayInList = _sqlActionUnit.ReadCustomersFromDatabase().ToList();
            //
            // lvDisplayCustomer.ItemsSource =customersToDisplayInList;

            // var customersWithContactList = _sqlActionUnit.GetCustomersWithContact();
            // lvDisplayCustomer.ItemsSource = customersWithContactList;

          //  var customersDisplay = _sqlActionUnit.GetCustomersWithPhone();
            lvDisplayCustomer.ItemsSource = _sqlActionUnit.GetCustomersWithPhone();
        }
        

        
    }
}
