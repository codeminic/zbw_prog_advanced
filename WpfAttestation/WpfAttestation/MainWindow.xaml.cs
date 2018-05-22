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
        private Data _data;

        public MainWindow()
        {
            InitializeComponent();
        }
            
        private void CloseButton_OnClick(object sender, RoutedEventArgs e)
        {
            _data.Save();
            Application.Current.Shutdown();
        }

        private void MainWindow_OnLoaded(object sender, RoutedEventArgs e)
        {
            _data = Data.Load();
            this.CustomerList.ItemsSource = _data.Customers.CustomerList;
            SetCurrentCustomer(_data.Customers.CustomerList[0]);
        }
        
        private void SetCurrentCustomer(Customer customer)
        {
            DataContext = customer;
        }

        private void CustomerList_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedCustomer = (Customer)e.AddedItems[0];
            SetCurrentCustomer(selectedCustomer);
            _data.Save();
        }

    }
}
