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

namespace Customer_Case_System.Views
{
    /// <summary>
    /// Interaction logic for RegisterCaseView.xaml
    /// </summary>
    public partial class RegisterCaseView : UserControl
    {
        private SqlActionUnit _sqlActionUnit = new SqlActionUnit();
        private int StatusOfCase;
        public RegisterCaseView()
        {
            InitializeComponent();
            
        }

        private void btnShowCustomersInDatabase(object sender, RoutedEventArgs e)
        {
            // var customersToDisplayInList = _sqlActionUnit.ReadCustomersFromDatabase().ToList();
            //
            // lvDisplayCustomer.ItemsSource =customersToDisplayInList;

            // var customersWithContactList = _sqlActionUnit.GetCustomersWithContact();
            // lvDisplayCustomer.ItemsSource = customersWithContactList;

            //  var customersDisplay = _sqlActionUnit.GetCustomersWithPhone();
            lvDisplayCustomerInCase.ItemsSource = _sqlActionUnit.ReadCustomersFromDatabase().ToList();
        }

        private void btnTest_Click(object sender, RoutedEventArgs e)
        {
            var checkedItem = listboxStatus.SelectedItem;

            if (checkedItem.Equals(item1))
            {
                tblockListBoxOk.Text = "0";
                StatusOfCase = 0;
            }
            else if (listboxStatus.SelectedItem.Equals(item2))
            {
                tblockListBoxOk.Text = "2";
                StatusOfCase = 2;
            }
            else if (listboxStatus.SelectedItem.Equals(item3))
            {
                tblockListBoxOk.Text = "3";
                StatusOfCase = 3;
            }
            else
                tblockListBoxOk.Text = "4";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _sqlActionUnit.InitializeStatusOfCase();
            var caseNumberId = _sqlActionUnit.RegisterCaseNumber(tboxCaseHeader.Text, Convert.ToInt32(tboxCustomerId.Text));
            _sqlActionUnit.RegisterCaseDetails(caseNumberId, tboxDescription.Text, StatusOfCase);
        }
    }
}
