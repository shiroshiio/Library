using System;
using System.Data.SQLite;
using System.Windows.Forms;

namespace Inventario.Vistas
{
    public partial class Reservas : Form
    {
        public Reservas()
        {
            InitializeComponent();
        }

        // Función para ejecutar comandos SQL
        private void EjecutarComandoSql(string query, SQLiteParameter[] parameters = null)
        {
            string connectionString = "Data Source=biblioteca.db;Version=3;";

            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(connectionString))
                {
                    SQLiteCommand cmd = new SQLiteCommand(query, conn);
                    if (parameters != null)
                        cmd.Parameters.AddRange(parameters);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al ejecutar el comando SQL: " + ex.Message);
            }
        }

        // Función para cargar los libros disponibles
        private void CargarLibros()
        {
            string query = "SELECT ISBN, Titulo FROM Libros WHERE ISBN NOT IN (SELECT ISBN FROM Reservas)";
            string connectionString = "Data Source=biblioteca.db;Version=3;";

            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(connectionString))
                {
                    conn.Open();
                    SQLiteCommand cmd = new SQLiteCommand(query, conn);
                    SQLiteDataReader reader = cmd.ExecuteReader();

                    comboBoxLibros.Items.Clear(); // Limpiar elementos previos

                    while (reader.Read())
                    {
                        // Solo agregamos el título al ComboBox, sin mostrar otras propiedades
                        comboBoxLibros.Items.Add(reader.GetString(1)); // Título
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los libros: " + ex.Message);
            }
        }

        // Evento que se ejecuta cuando se hace clic en "Reservar"
        private void ButtonReservar_Click(object sender, EventArgs e)
        {
            if (comboBoxLibros.SelectedItem != null)
            {
                string libroSeleccionado = comboBoxLibros.SelectedItem.ToString(); // Obtener solo el título
                string idUsuarioStr = textBoxUsuarioID.Text;

                if (int.TryParse(idUsuarioStr, out int idUsuario))
                {
                    string queryCheck = "SELECT COUNT(*) FROM Reservas WHERE ISBN = (SELECT ISBN FROM Libros WHERE Titulo = @Titulo)";
                    string connectionString = "Data Source=biblioteca.db;Version=3;";

                    try
                    {
                        using (SQLiteConnection conn = new SQLiteConnection(connectionString))
                        {
                            conn.Open();
                            SQLiteCommand cmdCheck = new SQLiteCommand(queryCheck, conn);
                            cmdCheck.Parameters.AddWithValue("@Titulo", libroSeleccionado);

                            int count = Convert.ToInt32(cmdCheck.ExecuteScalar());

                            if (count == 0)
                            {
                                // Realizamos la reserva del libro
                                string queryInsert = "INSERT INTO Reservas (ISBN, IDUsuario, FechaReserva) VALUES ((SELECT ISBN FROM Libros WHERE Titulo = @Titulo), @IDUsuario, @FechaReserva)";
                                SQLiteParameter[] parameters = {
                                    new SQLiteParameter("@Titulo", libroSeleccionado),
                                    new SQLiteParameter("@IDUsuario", idUsuario),
                                    new SQLiteParameter("@FechaReserva", DateTime.Now)
                                };

                                EjecutarComandoSql(queryInsert, parameters);

                                MessageBox.Show($"El libro '{libroSeleccionado}' ha sido reservado con éxito.");
                                CargarLibros();
                            }
                            else
                            {
                                MessageBox.Show($"El libro '{libroSeleccionado}' ya está reservado.");
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al reservar el libro: " + ex.Message);
                    }
                }
                else
                {
                    MessageBox.Show("Debe ingresar un ID de usuario válido.");
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar un libro.");
            }
        }

        // Evento para cargar los libros cuando se abre el formulario
        private void Reservas_Load(object sender, EventArgs e)
        {
            CargarLibros();
        }
    }
}
