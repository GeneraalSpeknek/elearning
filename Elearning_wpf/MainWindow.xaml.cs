using System;
using System.Collections.Generic;
using System.Data;
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

namespace Elearning_wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string IdVak="";

        struct Vakken
        {
            public string Id { get; set; }
            public string VakNaam { get; set; }
        }

        public MainWindow()
        {
            InitializeComponent();
            PopulateLb();
        }

        private void PopulateLb()
        {
            DataTable dtVakken = new Dbs_Conn().GetVakken();
            List<Vakken> lstVakken = new List<Vakken>();

            foreach (DataRow drVakken in dtVakken.Rows)
            {
                lstVakken.Add(new Vakken() {Id = drVakken[0].ToString(), VakNaam = drVakken[1].ToString() });
            }
            lbVakken.ItemsSource = lstVakken;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            //voeg inhoud van textbox toe aan database
            new Dbs_Conn().AddVak(tbVak.Text);
            PopulateLb();
            tbVak.Text = "";
        }

        private void btChangeVak_Click(object sender, RoutedEventArgs e)
        {
            new Dbs_Conn().ChangeVak(IdVak, tbVak.Text);
            PopulateLb();
            tbVak.Text = "";
        }

        private void lbVakken_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            IdVak = ((Vakken)(lbVakken.SelectedItem)).Id;
            tbVak.Text = ((Vakken)(lbVakken.SelectedItem)).VakNaam;

        }
    }
}
