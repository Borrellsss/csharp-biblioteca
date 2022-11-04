//Si vuole progettare un sistema per la gestione di una biblioteca. Gli utenti si possono registrare al sistema, fornendo:
//cognome,
//nome,
//email,
//password,
//recapito telefonico,
//Gli utenti registrati possono effettuare dei prestiti sui documenti che sono di vario tipo (libri, DVD).
//I documenti sono caratterizzati da:
//un codice identificativo di tipo stringa (ISBN per i libri, numero seriale per i DVD),
//titolo,
//anno,
//settore(storia, matematica, economia, …),
//stato(In Prestito, Disponibile),
//uno scaffale in cui è posizionato,
//un autore (Nome, Cognome).
//Per i libri si ha in aggiunta il numero di pagine, mentre per i dvd la durata.
//L’utente deve poter eseguire delle ricerche per codice o per titolo e, eventualmente,
//effettuare dei prestiti registrando il periodo (Dal/Al) del prestito e il documento.
//Deve essere possibile effettuare la ricerca dei prestiti dato nome e cognome di un utente.

//PROGRAMMA
Biblioteca nuovaBiblioteca = new Biblioteca("Biblioteca1");

Console.WriteLine($"Benvenuto/a nella {nuovaBiblioteca.Nome}");
Console.WriteLine("Quale operazione desidera eseguire?");
Console.WriteLine("1: prestito");
Console.WriteLine("2: registrazione");

string sceltaPrincipaleUtente = Console.ReadLine().ToLower();

if(sceltaPrincipaleUtente == "prestito")
{
    Console.WriteLine("Inserisca email e password:");

    Console.Write("Email: ");
    string emailUtente = Console.ReadLine();
    Console.WriteLine();

    Console.Write("Password: ");
    string passwordUtente = Console.ReadLine();
    Console.WriteLine();

    bool esitoControllo = nuovaBiblioteca.ConrolloDatiUtente(emailUtente, passwordUtente);

    if(esitoControllo)
    {
        
    }
    else
    {
        Console.WriteLine("Mi dispiace ma Il tuo profilo non è presente nel nostro Database!");
        Console.WriteLine("Se lo desidera può effettuare una registrazione.");
    }
}
else if(sceltaPrincipaleUtente == "registrazione")
{
    Console.WriteLine("Inserisca tutti i dati obbligatori:");

    Console.Write("Nome: ");
    string nomeUtente = Console.ReadLine();
    Console.WriteLine();

    Console.Write("Cognome: ");
    string cognomeUtente = Console.ReadLine();
    Console.WriteLine();

    Console.Write("Email: ");
    string emailUtente = Console.ReadLine();
    Console.WriteLine();

    Console.Write("Password: ");
    string passwordUtente = Console.ReadLine();
    Console.WriteLine();

    Console.WriteLine("Desidera inserire anche il numero di telefono?");
    Console.WriteLine("1: sì");
    Console.WriteLine("2: no");
    string sceltaTelefonoUtente = Console.ReadLine().ToLower();

    if(sceltaTelefonoUtente == "sì")
    {
        Console.Write("Numero: ");
        string telefonoUtente = Console.ReadLine();
        Console.WriteLine();

        Utente nuovoUtente = new Utente(nomeUtente, cognomeUtente, emailUtente, passwordUtente, telefonoUtente);

        bool esitoRegistrazione = nuovaBiblioteca.AggiungiNuovoUtente(nuovoUtente);

        if(esitoRegistrazione)
        {
            Console.WriteLine("Complimenti! La registrazione è avvenuta con successo!");
        }
        else
        {
            Console.WriteLine("Il tuo profilo è già presente nel nostro Database!");
        }
        
    }
    else if(sceltaTelefonoUtente == "no")
    {
        Utente nuovoUtente = new Utente(nomeUtente, cognomeUtente, emailUtente, passwordUtente);

        bool esitoRegistrazione = nuovaBiblioteca.AggiungiNuovoUtente(nuovoUtente);

        if (esitoRegistrazione)
        {
            Console.WriteLine("Complimenti! La registrazione è avvenuta con successo!");
        }
        else
        {
            Console.WriteLine("Il tuo profilo è già presente nel nostro Database");
        }
    }
    else
    {
        Console.WriteLine("Mi spiace ma la risposta non è corretta");
    }
}
else
{
    Console.WriteLine("opzione non disponibile");
}

//CLASSI
public class Biblioteca
{
    public string Nome { get; private set; }
    public List<Utente> UtentiRegistrati { get; }
    public List<Documento> Documenti { get; }

    //COSTRUTTORI
    public Biblioteca(string nome)
    {
        this.Nome = nome;
    }

    //FUNZIONI
    public bool AggiungiNuovoUtente(Utente nuovoUtente)
    {
        if(!UtentiRegistrati.Contains(nuovoUtente))
        {
            UtentiRegistrati.Add(nuovoUtente);
            return true;
        }

        return false;
    }

    public bool ConrolloDatiUtente(string email, string password)
    {
        foreach(Utente utenteCorrente in UtentiRegistrati)
        {
            if
            (
                utenteCorrente.Email == email
                && utenteCorrente.Password == password
            )
            {
                return true;
            }
             
        }

        return false;
    }
}

public class Utente
{
    public string Nome { get; private set; }
    public string Cognome { get; private set; }
    public string Email { get; private set; }
    public string Password { get; private set; }
    public string Telefono { get; private set; }

    public List<string> Prestiti { get; private set; }

    //COSTRUTTORI
    public Utente(string nome, string cognome, string email, string password)
    {
        this.Nome = nome;
        this.Cognome = cognome;
        this.Email = email;
        this.Password = password;
        this.Telefono = null;
    }

    public Utente(string nome, string cognome, string email, string password, string telefono)
    {
        this.Nome = nome;
        this.Cognome = cognome;
        this.Email = email;
        this.Password = password;
        this.Telefono = telefono;
    }
}

public class Documento
{
    public string Titolo { get; protected set; }
    public string Anno { get; protected set; }
    public string Autore { get; protected set; }
    public string Settore { get; protected set; }
    public int Scaffale { get; protected set; }
    public bool Disponibile { get; protected set; }

    //COSTRUTTORI
    public Documento(string titolo, string anno, string autore)
    {
        this.Titolo = titolo;
        this.Anno = anno;
        this.Autore = autore;
        this.Settore = null;
        this.Scaffale = 0;
        this.Disponibile = true;
    }
    public Documento(string titolo, string anno, string autore, string settore, int scaffale)
    {
        this.Titolo = titolo;
        this.Anno = anno;
        this.Autore = autore;
        this.Settore = settore;
        this.Scaffale = scaffale;
        this.Disponibile = true;
    }
}

public class Libro : Documento
{
    public string Isbn { get; private set; }
    public int NumeroPagine { get; private set; }

    //COSTRUTTORI
    public Libro(string titolo, string anno, string autore, string isbn, int numeroPagine) : base(titolo, anno, autore)
    {
        this.Isbn = isbn;
        this.NumeroPagine = numeroPagine;
    }
    public Libro(string titolo, string anno, string autore, string settore, int scaffale, string isbn, int numeroPagine) : base(titolo, anno, autore, settore, scaffale)
    {
        this.Isbn = isbn;
        this.NumeroPagine = numeroPagine;
    }
}

public class Dvd : Documento
{
    public string NumeroSeriale { get; private set; }
    public int Durata { get; private set; }

    //COSTRUTTORI
    public Dvd(string titolo, string anno, string autore, string numeroSeriale, int durata) : base(titolo, anno, autore)
    {
        this.NumeroSeriale = numeroSeriale;
        this.Durata = durata;
    }
    public Dvd(string titolo, string anno, string autore, string settore, int scaffale, string numeroSeriale, int durata) : base(titolo, anno, autore, settore, scaffale)
    {
        this.NumeroSeriale = numeroSeriale;
        this.Durata = durata;
    }
}