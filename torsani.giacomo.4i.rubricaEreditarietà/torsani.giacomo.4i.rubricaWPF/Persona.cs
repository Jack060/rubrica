using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace torsani.giacomo._4i.rubricaWPF
{
    public class Persona
    {
        public int idPersona {  get; set; }
        public string Nome { get; set; }
        public string Cognome { get; set; }

        public Persona(){}
        // Costruisce una persona, partendo da una riga CSV
        public Persona(string riga)
        {
            string[] campi = riga.Split(';');
            
            if(campi.Count() != 3) 
            {
                throw new Exception("Le righe del file Persone.csv devono essere di 3 colonne");
            }
            //tenta di interpretare una stringa, in questo caso tenta di convertire campi[0] in un int (id).
            int id = 0;
            int.TryParse(campi[0], out id);
            idPersona = id;
            
            this.Nome = campi[1];
            this.Cognome = campi[2];
        }
    }

    public class Persone : List<Persona>
    {
        public Persone() { }
        public Persone(string nomeFile) 
        {
            //legge le persone
            StreamReader fin = new StreamReader(nomeFile);
            fin.ReadLine();

            while (!fin.EndOfStream)
            {
                base.Add(new Persona(fin.ReadLine()));
            }
            fin.Close();
        }
    }
}