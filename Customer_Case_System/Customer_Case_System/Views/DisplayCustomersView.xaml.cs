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

        public DisplayCustomersView()
        {
            InitializeComponent();
            lvDisplayCustomer.ItemsSource = _sqlActionUnit.GetCustomersWithEmail().ToList();
        }
    }
}
