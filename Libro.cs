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
