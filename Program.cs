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

Biblioteca nuovaBiblioteca = new Biblioteca("Biblioteca1");

bool programmaInEsecuzione = true;

while(programmaInEsecuzione)
{
    Console.WriteLine($"Benvenuto/a nella {nuovaBiblioteca.Nome}");
    Console.WriteLine("Quale operazione desidera eseguire?");
    Console.WriteLine("[1]: Prestito");
    Console.WriteLine("[2]: Registrazione");
    Console.WriteLine("[3]: Controllo prestiti");
    Console.WriteLine("[4]: Termina programma");

    string sceltaPrincipaleUtente = Console.ReadLine();
    //Console.Clear();

    switch (sceltaPrincipaleUtente)
    {
        case "1":
            {
                Console.WriteLine("Inserisca email e password:");

                Console.Write("Email: ");
                string emailUtente = Console.ReadLine();

                Console.Write("Password: ");
                string passwordUtente = Console.ReadLine();
                //Console.Clear();

                bool esitoControllo = nuovaBiblioteca.ConrolloDatiUtente(emailUtente, passwordUtente);

                if (esitoControllo)
                {
                    bool condizioneRichiestaOrdinazione = true;

                    while (condizioneRichiestaOrdinazione)
                    {
                        Console.WriteLine("Cosa desidera prendere in prestito?");
                        Console.WriteLine("[1]: Libro");
                        Console.WriteLine("[2]: Dvd");

                        string sceltaPrestitoUtente = Console.ReadLine();
                        //Console.Clear();

                        switch(sceltaPrestitoUtente)
                        {
                            case "1":
                                Console.Write("Digiti il codice ISBN o il titolo del libro che vorrebbe prendere in prestito: ");
                                string libroUtente = Console.ReadLine();
                                //Console.Clear();

                                bool esitoRicercaLibro = nuovaBiblioteca.ConrolloDatiDocumento(libroUtente);

                                if (esitoRicercaLibro)
                                {
                                    bool esitoPrestito = nuovaBiblioteca.RegistrazionePrestito(emailUtente, libroUtente);

                                    if (esitoPrestito)
                                    {
                                        Console.WriteLine("Ecco a lei il suo libro!");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Sono spiacente ma il libro è terminato!");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Mi dispiace ma questo libro non è presente nella nostra biblioteca...");
                                }

                                bool condizioneTermineOrdinazione = true;

                                while(condizioneTermineOrdinazione)
                                {
                                    Console.WriteLine("Vuole effettuare un altro ordine?");
                                    Console.WriteLine("[1]: Sì");
                                    Console.WriteLine("[2]: No");
                                    //Console.Clear();

                                    string terminaOrdinazione = Console.ReadLine();

                                    switch (terminaOrdinazione)
                                    {
                                        case "1":
                                            condizioneTermineOrdinazione = false;

                                            break;

                                        case "2":
                                            Console.WriteLine("Grazie!");
                                            condizioneTermineOrdinazione = false;
                                            condizioneRichiestaOrdinazione = false;

                                            break;

                                        default:
                                            Console.WriteLine("Opzione non disponibile");

                                            break;
                                    }
                                }
                                
                                break;

                            case "2":
                                Console.Write("Digiti il numero seriale o il titolo del dvd che vorrebbe prendere in prestito: ");
                                string dvdUtente = Console.ReadLine();
                                //Console.Clear();

                                bool esitoRicercaDvd = nuovaBiblioteca.ConrolloDatiDocumento(dvdUtente);

                                if (esitoRicercaDvd)
                                {
                                    bool esitoPrestito = nuovaBiblioteca.RegistrazionePrestito(emailUtente, dvdUtente);

                                    if (esitoPrestito)
                                    {
                                        Console.WriteLine("Ecco a lei il suo dvd!");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Sono spiacente ma il dvd è terminato!");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Mi dispiace ma questo dvd non è presente nella nostra biblioteca...");
                                }

                                condizioneTermineOrdinazione = true;

                                while (condizioneTermineOrdinazione)
                                {
                                    Console.WriteLine("Vuole effettuare un altro ordine?");
                                    Console.WriteLine("[1]: Sì");
                                    Console.WriteLine("[2]: No");
                                    //Console.Clear();

                                    int terminaOrdinazione = Convert.ToInt16(Console.ReadLine());

                                    switch (terminaOrdinazione)
                                    {
                                        case 1:
                                            condizioneTermineOrdinazione = false;

                                            break;

                                        case 2:
                                            Console.WriteLine("Grazie!");
                                            condizioneTermineOrdinazione = false;
                                            condizioneRichiestaOrdinazione = false;

                                            break;

                                        default:
                                            Console.WriteLine("Opzione non disponibile");

                                            break;
                                    }
                                }

                                break;

                            default:

                                Console.WriteLine("Mi dispiace non credo di aver capito...");
                                break;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Mi dispiace ma Il tuo profilo non è presente nel nostro Database!");
                    Console.WriteLine("Se lo desidera può effettuare una registrazione.");
                }
            }

            bool richiestaContinua = true;

            while (richiestaContinua)
            {
                Console.WriteLine("Ha bisogno di altro?");
                Console.WriteLine("[1]: Sì");
                Console.WriteLine("[2]: No");

                string opzioneContinua = Console.ReadLine();

                switch (opzioneContinua)
                {
                    case "1":
                        //Console.Clear();
                        richiestaContinua = false;

                        break;

                    case "2":
                        //Console.Clear();
                        Console.WriteLine("Grazie e buona giornata!");
                        richiestaContinua = false;
                        programmaInEsecuzione = false;

                        break;

                    default:
                        //Console.Clear();
                        Console.WriteLine("Opzione non disponibile!");

                        break;
                }
            }

            break;

        case "2":
            {
                Console.WriteLine("Inserisca tutti i dati obbligatori:");

                Console.Write("Nome: ");
                string nomeUtente = Console.ReadLine();

                Console.Write("Cognome: ");
                string cognomeUtente = Console.ReadLine();

                Console.Write("Email: ");
                string emailUtente = Console.ReadLine();

                Console.Write("Password: ");
                string passwordUtente = Console.ReadLine();
                //Console.Clear();

                Console.WriteLine("Desidera inserire anche il numero di telefono?");
                Console.WriteLine("[1]: Sì");
                Console.WriteLine("[2]: No");
                string sceltaTelefonoUtente = Console.ReadLine();

                if (sceltaTelefonoUtente == "1")
                {
                    Console.Write("Numero: ");
                    string telefonoUtente = Console.ReadLine();
                    //Console.Clear();

                    Utente nuovoUtente = new Utente(nomeUtente, cognomeUtente, emailUtente, passwordUtente, telefonoUtente);

                    bool esitoRegistrazione = nuovaBiblioteca.AggiungiNuovoUtente(nuovoUtente);

                    if (esitoRegistrazione)
                    {
                        Console.WriteLine("Complimenti! La registrazione è avvenuta con successo!");
                    }
                    else
                    {
                        Console.WriteLine("Il tuo profilo è già presente nel nostro Database!");
                    }

                }
                else if (sceltaTelefonoUtente == "2")
                {
                    //Console.Clear();

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
                    //Console.Clear();
                    Console.WriteLine("Mi spiace ma la risposta non è corretta");
                }
            }

            richiestaContinua = true;

            while(richiestaContinua)
            {
                Console.WriteLine("Ha bisogno di altro?");
                Console.WriteLine("[1]: Sì");
                Console.WriteLine("[2]: No");

                string opzioneContinua = Console.ReadLine();

                switch (opzioneContinua)
                {
                    case "1":
                        //Console.Clear();
                        richiestaContinua = false;

                        break;

                    case "2":
                        //Console.Clear();
                        Console.WriteLine("Grazie e buona giornata!");
                        richiestaContinua = false;
                        programmaInEsecuzione = false;

                        break;

                    default:
                        //Console.Clear();
                        Console.WriteLine("Opzione non disponibile!");

                        break;
                }
            }

            break;

        case "3":
            //Console.Clear();
            Console.WriteLine("Inserisca Nome e Cognome: ");

            Console.Write("Nome: ");
            string nomeUtentePrestito = Console.ReadLine();

            Console.Write("Cognome: ");
            string CognomeUtentePrestito = Console.ReadLine();

            List<Prestito> prestitiUtente = nuovaBiblioteca.ListaPrestiti(nomeUtentePrestito, CognomeUtentePrestito);
            //Console.Clear();

            if(prestitiUtente.Count() > 0)
            {
                nuovaBiblioteca.StampaPrestitiUtente(prestitiUtente);
            }
            else
            {
                Console.WriteLine("Non sono presenti prestiti a questo nome.");
                Console.WriteLine("Se non è registrato/a può farlo tornando al menù principale.");
            }

            richiestaContinua = true;

            while (richiestaContinua)
            {
                Console.WriteLine("Ha bisogno di altro?");
                Console.WriteLine("[1]: Sì");
                Console.WriteLine("[2]: No");

                string opzioneContinua = Console.ReadLine();

                switch (opzioneContinua)
                {
                    case "1":
                        //Console.Clear();
                        richiestaContinua = false;

                        break;

                    case "2":
                        //Console.Clear();
                        Console.WriteLine("Grazie e buona giornata!");
                        richiestaContinua = false;
                        programmaInEsecuzione = false;

                        break;

                    default:
                        //Console.Clear();
                        Console.WriteLine("Opzione non disponibile!");

                        break;
                }
            }

            break;

        case "4":
            //Console.Clear();
            Console.WriteLine("Arrivederci!");
            programmaInEsecuzione = false;

            break;

        default:
            //Console.Clear();
            Console.WriteLine("opzione non disponibile");

            break;
    }
}