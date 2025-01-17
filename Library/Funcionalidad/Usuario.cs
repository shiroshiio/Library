public class Usuario
{
    public int IDUsuario { get; set; }
    public string Nombre { get; set; }
    public string Apellido { get; set; }
    public string Email { get; set; }
    public string Telefono { get; set; }

    public Usuario(int idUsuario, string nombre, string apellido, string email, string telefono)
    {
        IDUsuario = idUsuario;
        Nombre = nombre;
        Apellido = apellido;
        Email = email;
        Telefono = telefono;
    }
}
