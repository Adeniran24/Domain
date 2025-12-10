using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Domain
{
    

    public partial class MainWindow : Window
    {
        private ObservableCollection<DomainEntry> entries =
           new ObservableCollection<DomainEntry>();
        private readonly string csudhPath;
        private readonly string domainekPath;

        public MainWindow()
        {
            InitializeComponent();
            string basePath = AppDomain.CurrentDomain.BaseDirectory;
            csudhPath = System.IO.Path.Combine(basePath, "csudh.txt");
            domainekPath = System.IO.Path.Combine(basePath, "domainek.txt");
        }
    }
}