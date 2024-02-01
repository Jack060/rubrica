# rubricaWPF

## creazione file
installiamo e/o aggiornato tutti i pacchetti necessari di visual studio; <br>
scegliamo il modello del progetto "applicazione WPF" con il nome del file "cognome.nome.4i.rubrica; <br>
selezioniamo la versione corretta (in questo caso net 6.0)

## come creare la classe
tasto destro sul progetto: <br>
  -aggiungi <br>
  -classe <br>
  -inserire il nome "Contatto" <br>
  
poi dentro la classe inserire gli attributi:
```c#
        private int _numero;
        private string _cognome;
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
        public string Nome { get; set; }
        public string Cognome { get => _cognome; set => _cognome = value; }
        public string EMail { get; set; }
        public string Telefono { get; set; }
        public string Citta { get; set; }
        public string CAP { get; set; }
```
all'interno della classe di saranno 3 costruttori:
```c#
  public Contatto() { }

  public Contatto(string riga)
  {
    string[] campi = riga.Split(';');
    if (campi.Length >= 6)
    {   
        int pk = 0;
        if (int.TryParse(campi[0], out pk) == true)
        {
            Numero = pk;
        }
        else
        {
            Numero = 0;
        }
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
```

# rubricaWPF (seconda versione)

nella seconda versione abbiamo aggiunto un'altra griglia che contiene i contatti; nella prima (tabella a sinistra) <br>
c'è un'elenco di persone, nella seconda (tabella a destra) invece l'elenco dei contatti; <br>
E ogni volta che premiamo sulla linea di una persona nella prima tavella, nella seconda verrano visualizzati i contatti <br>
che si hanno con lo stesso "idPersona". in fondo alla finestra è stata aggiunta una scritta che mostra quante persone <br>
sono salvate, però se premiamo su una persona viene mostrato il nome della persona su cui abbiamo premuto.
