using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Data;
using System.Windows.Input;
using CustomerLib;

namespace CustomerApp.ViewModel
{
    public class CustomersViewModel : ViewModelBase
    {
        readonly CustomerRepository customerRepository = new CustomerRepository();
        private readonly ObservableCollection<CustomerViewModel> customers;

        public CustomersViewModel()
        {
            var customerViewModels = customerRepository.Customers.Select(c => new CustomerViewModel(c));
            customers = new ObservableCollection<CustomerViewModel>(customerViewModels);
            customerView = (CollectionView)CollectionViewSource.GetDefaultView(customers);
        }

        private CustomerViewModel selectedCustomer;
        public CustomerViewModel SelectedCustomer
        {
            get { return selectedCustomer; }
            set
            {
                selectedCustomer = value;
                RaisePropertyChanged("SelectedCustomer");
            }
        }

        private ICommand goFirstCommand;
        public ICommand GoFirstCommand => goFirstCommand ?? (goFirstCommand = new RelayCommand(GoFirst));

        private void GoFirst(object obj)
        {
            customerView.MoveCurrentToFirst();
            SelectedCustomer = (CustomerViewModel)customerView.CurrentItem;
        }

        private ICommand goPrevCommand;
        public ICommand GoPrevCommand => goPrevCommand ?? (goPrevCommand = new RelayCommand(GoPrev));

        private void GoPrev(object obj)
        {
            customerView.MoveCurrentToPrevious();
            SelectedCustomer = (CustomerViewModel)customerView.CurrentItem;
        }

        private ICommand goNextCommand;
        public ICommand GoNextCommand => goNextCommand ?? (goNextCommand = new RelayCommand(GoNext));

        private void GoNext(object obj)
        {
            customerView.MoveCurrentToNext();
            SelectedCustomer = (CustomerViewModel)customerView.CurrentItem;
        }

        private ICommand goLastCommand;
        public ICommand GoLastCommand => goLastCommand ?? (goLastCommand = new RelayCommand(GoLast));

        private void GoLast(object obj)
        {
            customerView.MoveCurrentToLast();
            SelectedCustomer = (CustomerViewModel)customerView.CurrentItem;
        }
        private string searchText;
        public string SearchText
        {
            get { return searchText; }
            set
            {
                searchText = value;
                RaisePropertyChanged("SearchText");
            }
        }

        public ObservableCollection<CustomerViewModel> Customers
        {
            get { return customers; }
        }

        private ICommand addCommand;
        public ICommand AddCommand
        {
            get { return addCommand ?? (addCommand = new RelayCommand(AddCustomer, null)); }
        }

        private void AddCustomer(object obj)
        {
            var customer = new Customer();
            var customerViewModel = new CustomerViewModel(customer);
            customers.Add(customerViewModel);
            customerRepository.Add(customer);
            SelectedCustomer = customerViewModel;
        }

        private ICommand removeCommand;
        public ICommand RemoveCommand
        {
            get {
                return removeCommand ??
                       (removeCommand = new RelayCommand(RemoveCustomer, c => SelectedCustomer != null));
            }
        }

        private void RemoveCustomer(object obj)
        {
            customerRepository.Remove(SelectedCustomer.Customer);
            customers.Remove(SelectedCustomer);
            SelectedCustomer = null;
        }

        private ICommand saveCommand;
        public ICommand SaveCommand
        {
            get { return saveCommand ?? (saveCommand = new RelayCommand(SaveData, null)); }
        }

        private void SaveData(object obj)
        {
            customerRepository.Commit();
        }

        private ICommand searchCommand;
        private ICollectionView customerView;

        public ICommand SearchCommand
        {
            get
            {
                if (searchCommand == null)
                    searchCommand = new RelayCommand(SearchData, null);
                return searchCommand;
            }
        }

        private void SearchData(object obj)
        {
            customerView.Filter = !string.IsNullOrWhiteSpace(SearchText) ?
                c => ((CustomerViewModel)c).Country.ToLower().Contains(SearchText.ToLower()) :
                (Predicate<object>)null;
        }

    }

}
