public class Biblioteca
{
    public string Nome { get; private set; }
    public List<Utente> UtentiRegistrati { get; private set; }
    public List<Documento> Documenti { get; }

    //COSTRUTTORI
    public Biblioteca(string nome)
    {
        this.Nome = nome;
        this.UtentiRegistrati = new List<Utente>();
        this.Documenti = new List<Documento>();

        Utente utenteTest = new Utente("Edoardo", "Borrello", "edoardo@mail.it", "12345678");

        this.AggiungiNuovoUtente(utenteTest);
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
