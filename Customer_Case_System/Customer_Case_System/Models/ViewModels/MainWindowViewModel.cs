using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Customer_Case_System.Helpers;
using Customer_Case_System.Models.ViewModels;

namespace Customer_Case_System.Models.ViewModels
{
    internal class MainWindowViewModel : ObservableObject
    {
        public RelayCommand RegisterCustomerViewCommand { get; set; }
        public RelayCommand RegisterCaseViewCommand { get; set; }
        public RelayCommand DisplayCustomersViewCommand { get; set; }
        public RelayCommand DisplayCasesViewCommand { get; set; }
        
        public RegisterCustomerViewModel RegisterCustomerViewModel { get; set; }
        public RegisterCaseViewModel RegisterCaseViewModel { get; set; }
        public DisplayCustomersViewModel DisplayCustomersViewModel { get; set; }
        public DisplayCasesViewModel DisplayCasesViewModel { get; set; }

        private object _currentView;
        public object CurrentView
        {
            get
            {
                return _currentView;
            }
            set
            {
                _currentView = value;
                OnPropertyChanged();
            }
        }

        public MainWindowViewModel()
        {
            RegisterCustomerViewModel = new RegisterCustomerViewModel();
            RegisterCaseViewModel = new RegisterCaseViewModel();
            DisplayCustomersViewModel = new DisplayCustomersViewModel();
            DisplayCasesViewModel = new DisplayCasesViewModel();
            
            CurrentView = RegisterCustomerViewModel;

            RegisterCustomerViewCommand = new RelayCommand(x => CurrentView = RegisterCustomerViewModel);
            RegisterCaseViewCommand = new RelayCommand(x => CurrentView = RegisterCaseViewModel);
            DisplayCustomersViewCommand = new RelayCommand(x => CurrentView = DisplayCustomersViewModel);
            DisplayCasesViewCommand = new RelayCommand(x => CurrentView = DisplayCasesViewModel);
        }
    }
}
