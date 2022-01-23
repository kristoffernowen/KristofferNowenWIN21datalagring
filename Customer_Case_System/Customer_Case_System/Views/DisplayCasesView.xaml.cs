using System.Windows.Controls;
using Customer_Case_System.DatabaseActionUnits;

namespace Customer_Case_System.Views
{
    /// <summary>
    /// Interaction logic for DisplayCasesView.xaml
    /// </summary>
    // ReSharper disable once RedundantExtendsListEntry
    public partial class DisplayCasesView : UserControl
    {
        private readonly SqlActionUnit _actionUnit = new(); 
        public DisplayCasesView()
        {
            InitializeComponent();
            lvCases.ItemsSource = _actionUnit.GetCasesWithCustomerInfo();
        }
    }
}
