public class Dvd : Documento
{
    public int Durata { get; private set; }

    //COSTRUTTORI
    public Dvd(string titolo, string anno, string autore, string codice, int durata) : base(titolo, anno, autore, codice)
    {
        this.Durata = durata;
    }
    public Dvd(string titolo, string anno, string autore, string settore, int scaffale, string codice, int durata) : base(titolo, anno, autore, codice, settore, scaffale)
    {
        this.Durata = durata;
    }
}