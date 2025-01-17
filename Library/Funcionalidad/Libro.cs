public class Libro
{
    public string ISBN { get; set; }
    public string Titulo { get; set; }
    public string Autor { get; set; }
    public string Editorial { get; set; }
    public int AnoPublicacion { get; set; }
    public string Genero { get; set; }
    public int Copias { get; set; }

    public Libro(string isbn, string titulo, string autor, string editorial, int anoPublicacion, string genero, int copias)
    {
        ISBN = isbn;
        Titulo = titulo;
        Autor = autor;
        Editorial = editorial;
        AnoPublicacion = anoPublicacion;
        Genero = genero;
        Copias = copias;
    }
}
