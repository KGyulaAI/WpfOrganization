using System;
using System.Collections.Generic;
using System.IO;
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

namespace WpfOrganization
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Betoltes("organizations-100000.csv");
            dgAdatok.ItemsSource = szervezetekLista;
        }
        
        List<Organization> szervezetekLista = new List<Organization>();

        private void Betoltes(string fileName)
        {
            foreach (var sor in File.ReadAllLines(fileName).Skip(1))
            {
                szervezetekLista.Add(new Organization(sor.Split(';')));
            }
        }

        private void dgAdatok_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgAdatok.SelectedItem is Organization)
            {
                Organization valasztottObjektum = dgAdatok.SelectedItem as Organization;
            }
            else
            {
                MessageBox.Show("Hiba!");
            }
        }
    }
}
