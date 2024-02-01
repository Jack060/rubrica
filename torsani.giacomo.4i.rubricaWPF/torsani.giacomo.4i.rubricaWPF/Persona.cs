using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace torsani.giacomo._4i.rubricaWPF
{
    internal class Persona
    {
        public int idPersona {  get; set; }
        public string Nome { get; set; }
        public string Cognome { get; set; }

        public Persona(){}
        // Costruisce una persona, partendo da una riga CSV
        public Persona(string riga)
        {
            string[] campi = riga.Split(';');
            //tenta di interpretare una stringa, in questo caso tenta di convertire campi[0] in un int (id).
            
            int id = 0;
            int.TryParse(campi[0], out id);
            idPersona = id;
            
            this.Nome = campi[1];
            this.Cognome = campi[2];
        }
    }
}