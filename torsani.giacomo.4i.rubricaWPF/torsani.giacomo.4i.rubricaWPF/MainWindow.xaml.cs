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
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Torsani_Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                const int MAX = 100;
                StreamReader fin = new StreamReader("Dati.csv");
                Contatto[] Contatti = new Contatto[MAX];

                // for (int i = 0; i < Contatti.Length; i++)

                int idx = 0;

                while (!fin.EndOfStream)
                {
                    if (idx < MAX)
                    {
                        string riga = fin.ReadLine();
                        Contatto c = new Contatto(riga);
                        Contatti[idx++] = c;
                    }
                    else
                        break;
                }

                for (; idx < MAX; idx++)
                {
                    Contatto c = new Contatto();
                    Contatti[idx] = c;
                }
                dgDati.ItemsSource = Contatti;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"No no!!\n{ex.Message}\n nella colonna PK non ci sono solo numeri" + ex.Message);
            }
        }
        private void dgDati_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            Contatto c = e.Row.Item as Contatto;
            if (c != null)
            {
                if (c.Numero == 0)
                {
                    e.Row.Background = Brushes.Red;
                    e.Row.Foreground = Brushes.Black;
                }
                else if (c.Numero != 0)
                {
                    e.Row.Background = Brushes.Green;
                    e.Row.Foreground = Brushes.White;
                }
                string numstring = "0";
                numstring = Convert.ToString(c.Telefono);
                if (numstring != null)
                {
                    char chars = numstring.First();
                    if (chars == '3')
                    {
                        e.Row.Background = Brushes.Yellow;
                        e.Row.Foreground= Brushes.Black;
                    }
                }
            }
            
        }
    }
}