using CustomerApp.ViewModel;
using System.Windows;
using System.Windows.Controls;
using System.IO;
using System.Windows.Markup;

namespace CustomerApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new CustomersViewModel();
        }

        private void SelectedViewChanged(object sender, SelectionChangedEventArgs e)
        {
            var viewIndex = (sender as ComboBox).SelectedIndex;
            FrameworkElement view = null;
            switch (viewIndex)
            {
                case 0:
                    view = LoadView("masterdetail.xaml");
                    break;
                case 1:
                    view = LoadView("detail.xaml");
                    break;
                case 2:
                    view = LoadView("master.xaml");
                    break;
            }
            MainContent.Content = view;
        }

        private FrameworkElement LoadView(string fileName)
        {
            using (FileStream fs = new FileStream(fileName, FileMode.Open))
            {
                return XamlReader.Load(fs) as FrameworkElement;
            }
        }
    }
}
