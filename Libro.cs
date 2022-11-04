public class Libro : Documento
{
    public string Isbn { get; private set; }
    public int NumeroPagine { get; private set; }

    //COSTRUTTORI
    public Libro(string titolo, string anno, string autore, string codice, int numeroPagine) : base(titolo, anno, autore, codice)
    {
        this.NumeroPagine = numeroPagine;
    }
    public Libro(string titolo, string anno, string autore, string settore, int scaffale, string codice, int numeroPagine) : base(titolo, anno, autore, codice, settore, scaffale)
    {
        this.NumeroPagine = numeroPagine;
    }
}