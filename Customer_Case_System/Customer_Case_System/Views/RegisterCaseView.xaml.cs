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
    /// Interaction logic for RegisterCaseView.xaml
    /// </summary>
    public partial class RegisterCaseView : UserControl
    {
        private SqlActionUnit _sqlActionUnit = new SqlActionUnit();
        private int StatusOfCase;
        public RegisterCaseView()
        {
            InitializeComponent();
            listboxCustomers.ItemsSource = _sqlActionUnit.ReadCustomersFromDatabase().ToList();
            tblockResultCase.Text = "";
        }
        
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var caseHeader = tboxCaseHeader.Text;

                var customer = (Customer)listboxCustomers.SelectedItem;

                var description = tboxDescription.Text;

                int checkedStatusIdItem = 0;
                if (listboxStatus.SelectedItem.Equals(item1))
                    checkedStatusIdItem = 1;
                else if (listboxStatus.SelectedItem.Equals(item2))
                    checkedStatusIdItem = 2;
                else if (listboxStatus.SelectedItem.Equals(item3))
                    checkedStatusIdItem = 3;

                var caseNumberId = _sqlActionUnit.RegisterCaseNumber(tboxCaseHeader.Text, customer.Id);
                _sqlActionUnit.RegisterCaseDetails(caseNumberId, tboxDescription.Text, checkedStatusIdItem);

                tblockResultCase.Text = "Ärende troligen tillagt";
            }
            catch
            {
                tblockResultCase.Text = "Du kanske lämnade något fält tomt eller inte markerade kund eller status";
            }
            
        }
    }
}
