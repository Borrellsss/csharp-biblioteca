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
        bool condizioneWhile1 = true;

        while(condizioneWhile1)
        {
            Console.WriteLine("Cosa desidera prendere in prestito?");
            Console.WriteLine("1: libro");
            Console.WriteLine("2: dvd");

            string sceltaPrestitoUtente = Console.ReadLine().ToLower();

            if (sceltaPrestitoUtente == "libro")
            {
                condizioneWhile1 = false;
            }
            else if (sceltaPrestitoUtente == "dvd")
            {
                condizioneWhile1 = false;
            }
            else
            {
                Console.WriteLine("Mi dispiace non credo di aver capito...");
            }
        }
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