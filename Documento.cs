﻿public class Documento
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
