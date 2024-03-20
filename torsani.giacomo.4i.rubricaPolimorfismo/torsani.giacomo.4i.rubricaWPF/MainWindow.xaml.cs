using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
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

namespace torsani.giacomo._4i.rubricaWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Persone persone;
        Contatti contatti;
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Torsani_Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                persone = new Persone("Persone.csv");
                dgPersone.ItemsSource = persone;

                contatti = new Contatti("Contatti.csv");
                
                statusbar.Text = $"Ho letto {persone.Count} persone e {contatti.Count} contatti";
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgDati_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // "e" è un oggetto, con "as" lo trasformiamo nell'oggetto Contatto che spostiamo in "c"
            Persona p = e.AddedItems[0] as Persona;
            Contatti contattiFiltrati = new Contatti();
            if (p != null)
            {   
                statusbar.Text = $"Il contatto selezionato: {p.Nome}";
                
                foreach (Contatto item in contatti)
                {
                    if (item.idPersona == p.idPersona)
                    {
                        contattiFiltrati.Add(item);
                    }
                }
            }
             dgContatti.ItemsSource = contattiFiltrati;
        }

        private void dgContatti_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void dgPersone_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            Persona p = e.Row.Item as Persona;
            if (p != null)
            {
                if( p.idPersona == 1)
                {
                    e.Row.Background = Brushes.Red;
                    e.Row.Foreground = Brushes.White;
                }
            }
        }
    }
}