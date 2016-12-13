using System.Text.RegularExpressions;
using CustomerLib;

namespace CustomerApp.ViewModel
{
    public class CustomerViewModel : ViewModelBase
    {
        public Customer Customer { get; private set; }


        public CustomerViewModel(Customer cust)
        {
            Customer = cust;
        }


        public string CustomerId
        {
            get { return Customer.CustomerId; }
            set
            {
                Customer.CustomerId = value;
                RaisePropertyChanged("CustomerId");
            }
        }

        public string CompanyName
        {
            get { return Customer.CompanyName; }
            set
            {
                Customer.CompanyName = value;
                RaisePropertyChanged("CompanyName");
            }
        }

        public string ContactName
        {
            get { return Customer.ContactName; }
            set
            {
                Customer.ContactName = value;
                RaisePropertyChanged("ContactName");
            }
        }

        public string ContactTitle
        {
            get { return Customer.ContactTitle; }
            set
            {
                Customer.ContactTitle = value;
                RaisePropertyChanged("ContactTitle");
            }
        }

        public string Region
        {
            get { return Customer.Region; }
            set
            {
                Customer.Region = value;
                RaisePropertyChanged("Region");
            }
        }

        public string Address
        {
            get { return Customer.Address; }
            set
            {
                Customer.Address = value;
                RaisePropertyChanged("Address");
            }
        }

        public string City
        {
            get { return Customer.City; }
            set
            {
                Customer.City = value;
                RaisePropertyChanged("City");
            }
        }

        public string Country
        {
            get { return Customer.Country; }
            set
            {
                Customer.Country = value;
                RaisePropertyChanged("Country");
            }
        }

        public string PostalCode
        {
            get { return Customer.PostalCode; }
            set
            {
                Customer.PostalCode = value;
                RaisePropertyChanged("PostalCode");
            }
        }

        public string Phone
        {
            get { return Customer.Phone; }
            set
            {
                Customer.Phone = value;
                RaisePropertyChanged("Phone");
            }
        }

        public string Fax
        {
            get { return Customer.Fax; }
            set
            {
                Customer.Fax = value;
                RaisePropertyChanged("Fax");
            }
        }
        
    }

}
