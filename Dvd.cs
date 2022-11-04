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