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
using System;
using System.IO;

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
            LoadFromFile();
            dgDomains.ItemsSource = entries;
        }
        private void LoadFromFile()
        {
            try
            {
                if (!File.Exists(csudhPath))
                {
                    MessageBox.Show("A csudh.txt nem található!\nElérési út: " + csudhPath);
                    return;
                }


                var lines = File.ReadAllLines(csudhPath, Encoding.UTF8);

                entries.Clear();

                for (int i = 1; i < lines.Length; i++)
                {
                    if (string.IsNullOrWhiteSpace(lines[i]))
                        continue;

                    entries.Add(new DomainEntry(lines[i]));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hiba a beolvasáskor: " + ex.Message);
            }
        }
        private void btnBevitel_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string domain = tbDomain.Text.Trim();
                string ip = tbIp.Text.Trim();

                if (string.IsNullOrWhiteSpace(domain) ||
                    string.IsNullOrWhiteSpace(ip))
                {
                    MessageBox.Show("Mindkét mezőt ki kell tölteni!");
                    return;
                }

                entries.Add(new DomainEntry(domain, ip));

                tbDomain.Text = "";
                tbIp.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hiba bevitelkor: " + ex.Message);
            }
        }
        private void btnMentes_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                var lines = entries
                    .Select(e2 => e2.ToString())
                    .ToList();

                File.WriteAllLines(domainekPath, lines, Encoding.UTF8);

                MessageBox.Show("Sikeres Mentés!");
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
    }
}