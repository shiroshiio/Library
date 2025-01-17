public class Reserva
{
    public int IDReserva { get; set; }
    public int IDUsuario { get; set; }
    public string ISBN { get; set; }
    public DateTime FechaReserva { get; set; }
    public DateTime FechaRetorno { get; set; }

    public Reserva(int idReserva, int idUsuario, string isbn, DateTime fechaReserva, DateTime fechaRetorno)
    {
        IDReserva = idReserva;
        IDUsuario = idUsuario;
        ISBN = isbn;
        FechaReserva = fechaReserva;
        FechaRetorno = fechaRetorno;
    }
}
