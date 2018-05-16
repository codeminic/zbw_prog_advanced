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
using Datasource;

namespace WpfAttestation
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private IList<Customer> _customers;
        private int _currentCustomerIndex = 0;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void CloseButton_OnClick(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();

        }

        private void MainWindow_OnLoaded(object sender, RoutedEventArgs e)
        {
            _customers = Datasource.Data.Load().Customers.CustomerList;
            SetCurrentCustomer(_customers[0]);
        }

        private void PreviousButton_OnClick(object sender, RoutedEventArgs e)
        {
            if (_currentCustomerIndex > 0)
            {
                SetCurrentCustomer(_customers[_currentCustomerIndex - 1]);
                _currentCustomerIndex--;
            }
        }

        private void NextButton_OnClick(object sender, RoutedEventArgs e)
        {
            if (_currentCustomerIndex < _customers.Count - 1)
            {
                SetCurrentCustomer(_customers[_currentCustomerIndex + 1]);
                _currentCustomerIndex++;
            }
        }

        private void SetCurrentCustomer(Customer customer)
        {
            DataContext = customer;
        }
    }
}
