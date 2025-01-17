using System;
using System.Data.SQLite;
using System.Windows.Forms;

namespace Library
{
    public partial class UsuarioInfo : Form
    {
        private int _idUsuario;

        // Constructor que recibe el IDUsuario
        public UsuarioInfo(int idUsuario)
        {
            InitializeComponent();
            _idUsuario = idUsuario; // Guardamos el IDUsuario
            LoadUsuarioInfo();  // Llamamos al método para cargar la información del usuario
        }

        private void LoadUsuarioInfo()
        {
            string connectionString = "Data Source=biblioteca.db;Version=3;";
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT IDUsuario, Nombre, Apellido, Email, Telefono FROM Usuarios WHERE IDUsuario = @IDUsuario";

                    using (SQLiteCommand cmd = new SQLiteCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@IDUsuario", _idUsuario); // Usamos el IDUsuario pasado
                        using (SQLiteDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Mostrar la información en los controles del formulario
                                labelIDUsuario.Text = "ID Usuario: " + reader["IDUsuario"].ToString();
                                labelNombre.Text = "Nombre: " + reader["Nombre"].ToString();
                                labelApellido.Text = "Apellido: " + reader["Apellido"].ToString();
                                labelEmail.Text = "Email: " + reader["Email"].ToString();
                                labelTelefono.Text = "Teléfono: " + reader["Telefono"].ToString();
                            }
                            else
                            {
                                MessageBox.Show("No se encontró el usuario.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar la información del usuario: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }

    // Definición de la clase Usuario
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
}
