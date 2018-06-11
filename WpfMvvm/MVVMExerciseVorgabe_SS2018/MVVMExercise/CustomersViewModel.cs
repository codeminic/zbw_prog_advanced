using System.Collections.ObjectModel;
using Datasource;
using WpfExercise;
using WpfExercise.Services;

namespace MVVMExercise
{
    public class CustomersViewModel
    {
        public ObservableCollection<Customer> Customers { get; set; }

        public Customer CurrentCustomer { get; set; }

        public RelayCommand SaveCommand { get; set; }

        public CustomersViewModel()
        {
            var customersRepository = new CustomersRepository();
            Customers = new ObservableCollection<Customer>(customersRepository.GetCustomersAsync().Result);
            SaveCommand = new RelayCommand(() => customersRepository.UpdateCustomerAsync(CurrentCustomer));
        }
    }
}