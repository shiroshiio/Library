using System;
using System.Data.SQLite;
using System.Windows.Forms;

namespace Library
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // Método para verificar si hay campos vacíos
        private bool AreFieldsEmpty()
        {
            return string.IsNullOrWhiteSpace(textBox1.Text) ||
                   string.IsNullOrWhiteSpace(textBox2.Text) ||
                   string.IsNullOrWhiteSpace(textBox3.Text) ||
                   string.IsNullOrWhiteSpace(textBox4.Text) ||
                   string.IsNullOrWhiteSpace(textBox5.Text);
        }

        // Evento para el botón de registrar
        private void button1_Click(object sender, EventArgs e)
        {
            if (AreFieldsEmpty())
            {
                MessageBox.Show("Por favor, complete todos los campos.");
                return;
            }

            string nombre = textBox1.Text;
            string apellido = textBox2.Text;
            string email = textBox4.Text;
            string telefono = textBox5.Text;

            // Inserción de datos en la base de datos
            string query = "INSERT INTO Usuarios (Nombre, Apellido, Email, Telefono) VALUES (@Nombre, @Apellido, @Email, @Telefono)";

            using (SQLiteConnection conn = new SQLiteConnection("Data Source=biblioteca.db;Version=3;"))
            {
                try
                {
                    conn.Open();
                    using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                    {
                        // Parametrizar la consulta para evitar inyección SQL
                        cmd.Parameters.AddWithValue("@Nombre", nombre);
                        cmd.Parameters.AddWithValue("@Apellido", apellido);
                        cmd.Parameters.AddWithValue("@Email", email);
                        cmd.Parameters.AddWithValue("@Telefono", telefono);

                        cmd.ExecuteNonQuery();
                    }

                    // Obtener el último IDUsuario insertado
                    string getLastUserIdQuery = "SELECT last_insert_rowid()";
                    using (SQLiteCommand cmd = new SQLiteCommand(getLastUserIdQuery, conn))
                    {
                        long lastInsertId = (long)cmd.ExecuteScalar();

                        // Abrir el formulario MainMenu y pasar el IDUsuario
                        MainMenu mainMenuForm = new MainMenu((int)lastInsertId);
                        this.Hide(); // Ocultar el formulario de registro
                        mainMenuForm.Show(); // Mostrar el formulario MainMenu
                    }

                    MessageBox.Show("Usuario registrado con éxito.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al registrar el usuario: " + ex.Message);
                }
            }
        }

        // Evento para inicializar el botón de registro con el método button1_Click
        private void Form1_Load(object sender, EventArgs e)
        {
            button1.Click += button1_Click;
        }
    }
}
