using System;
using System.Data.SQLite;
using System.Windows.Forms;

namespace Inventario.Vistas
{
    public partial class Consultas : Form
    {
        public Consultas()
        {
            InitializeComponent();
        }

        // Función para ejecutar comandos SQL
        private void EjecutarComandoSql(string query, SQLiteParameter[] parameters = null)
        {
            string connectionString = "Data Source=biblioteca.db;Version=3;"; // Cambia esto si es necesario

            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                SQLiteCommand cmd = new SQLiteCommand(query, conn);
                if (parameters != null)
                    cmd.Parameters.AddRange(parameters);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // Función para cargar los libros en el DataGridView
        private void CargarLibros()
        {
            string query = @"
                SELECT L.ISBN, L.Titulo, L.Genero, 
                CASE 
                    WHEN R.ISBN IS NOT NULL THEN 'Reservado' 
                    ELSE 'Disponible' 
                END AS Estado
                FROM Libros L
                LEFT JOIN Reservas R ON L.ISBN = R.ISBN
                ORDER BY L.Titulo";

            try
            {
                using (SQLiteConnection conn = new SQLiteConnection("Data Source=biblioteca.db;Version=3;"))
                {
                    conn.Open();
                    SQLiteCommand cmd = new SQLiteCommand(query, conn);
                    SQLiteDataReader reader = cmd.ExecuteReader();

                    // Limpiar los elementos del DataGridView antes de agregar nuevos
                    dataGridViewLibros.Rows.Clear();

                    // Agregar los libros al DataGridView
                    while (reader.Read())
                    {
                        string estado = reader.IsDBNull(3) ? "Desconocido" : reader.GetString(3); // Verificar si el valor es nulo
                        dataGridViewLibros.Rows.Add(reader.GetString(0), reader.GetString(1), reader.GetString(2), estado); // Cambiar de GetInt32 a GetString para ISBN
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los libros: " + ex.Message);
            }
        }

        // Evento para cargar los libros cuando se abre el formulario
        private void Consultas_Load(object sender, EventArgs e)
        {
            // Asegúrate de que las columnas estén correctamente configuradas
            dataGridViewLibros.Columns.Add("ISBNColumn", "ISBN");
            dataGridViewLibros.Columns.Add("TituloColumn", "Título");
            dataGridViewLibros.Columns.Add("GeneroColumn", "Género");
            dataGridViewLibros.Columns.Add("EstadoColumn", "Estado");

            CargarLibros();
        }
    }
}
