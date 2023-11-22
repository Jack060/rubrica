using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Packaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace torsani.giacomo._4i.rubricaWPF
{
    internal class Contatto
    {
        private int _numero;
        private string _cognome;
        public string Nome { get; set; }
        public string EMail { get; set; }
        public string Telefono { get; set; }
        public string Citta { get; set; }
        public string CAP { get; set; }
        public string Cognome { get => _cognome; set => _cognome = value; }
        public int Numero
        {
            get
            {
                return _numero;
            }

            set
            {
                if (value < 0 || value > 100)
                    throw new ArgumentOutOfRangeException();

                _numero = value;
            }
        }
        public Contatto() { }
        // Costruisce un Contatto, partendo da una riga CSV
        public Contatto(string riga)
        {
            string[] campi = riga.Split(';');
            if (campi.Length >= 6)
            {   
                int pk = 0;
                int.TryParse(campi[0], out pk);//tenta di interpretare una stringa, in questo caso tenta di convertire campi[0] in un int (pk).
                Numero = pk;
                Nome = campi[1];
                Cognome = campi[2];
                Telefono = campi[3];
                EMail = campi[4];
                Citta = campi[5];
                CAP = campi[6];
            }
        }

        public Contatto(int numero, string nome, string cognome)
        {
            Numero = numero;
            Nome = nome;
            Cognome = cognome;
        }
    }
}
