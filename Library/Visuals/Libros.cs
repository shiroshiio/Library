using System;
using System.Data.SQLite;
using System.Windows.Forms;

namespace Inventario.Vistas
{
    public partial class Libros : Form
    {
        public Libros()
        {
            InitializeComponent();
        }

        // Función para ejecutar comandos SQL
        private void EjecutarComandoSql(string query, SQLiteParameter[] parameters = null)
        {
            string connectionString = "Data Source=biblioteca.db;Version=3;"; // Ruta de tu base de datos SQLite

            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                SQLiteCommand cmd = new SQLiteCommand(query, conn);
                if (parameters != null)
                    cmd.Parameters.AddRange(parameters);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // Función para cargar los libros desde la base de datos
        private void CargarLibros()
        {
            // Limpiar el DataGridView antes de agregar nuevos datos
            dataGridView1.Rows.Clear();

            // Consulta para obtener los libros desde la base de datos
            string query = "SELECT ISBN, Titulo, Autor, Editorial, AnoPublicacion, Genero, Copias FROM Libros";

            using (SQLiteConnection conn = new SQLiteConnection("Data Source=biblioteca.db;Version=3;"))
            {
                conn.Open();
                SQLiteCommand cmd = new SQLiteCommand(query, conn);
                SQLiteDataReader reader = cmd.ExecuteReader();

                // Agregar los libros al DataGridView
                while (reader.Read())
                {
                    dataGridView1.Rows.Add(reader["ISBN"], reader["Titulo"], reader["Autor"], reader["Editorial"], reader["AnoPublicacion"], reader["Genero"], reader["Copias"]);
                }
            }
        }

        // Evento para agregar un nuevo libro
        private void ButtonAgregar_Click(object sender, EventArgs e)
        {
            // Prompt para ingresar los detalles del libro
            string isbn = Prompt.ShowDialog("Ingrese el ISBN del libro:", "Agregar Libro");
            string titulo = Prompt.ShowDialog("Ingrese el título del libro:", "Agregar Libro");
            string autor = Prompt.ShowDialog("Ingrese el autor del libro:", "Agregar Libro");
            string editorial = Prompt.ShowDialog("Ingrese la editorial del libro:", "Agregar Libro");
            string anoPublicacion = Prompt.ShowDialog("Ingrese el año de publicación del libro:", "Agregar Libro");
            string genero = Prompt.ShowDialog("Ingrese el género del libro:", "Agregar Libro");
            string copias = Prompt.ShowDialog("Ingrese la cantidad de copias del libro:", "Agregar Libro");

            if (!string.IsNullOrEmpty(isbn) && !string.IsNullOrEmpty(titulo) && !string.IsNullOrEmpty(autor) &&
                !string.IsNullOrEmpty(editorial) && !string.IsNullOrEmpty(anoPublicacion) && !string.IsNullOrEmpty(genero) && !string.IsNullOrEmpty(copias))
            {
                // Validar que el año de publicación y las copias sean números
                if (int.TryParse(anoPublicacion, out int year) && int.TryParse(copias, out int cantidad))
                {
                    // Insertar en la base de datos SQLite
                    string query = "INSERT INTO Libros (ISBN, Titulo, Autor, Editorial, AnoPublicacion, Genero, Copias) VALUES (@ISBN, @Titulo, @Autor, @Editorial, @AnoPublicacion, @Genero, @Copias)";
                    SQLiteParameter[] parameters = {
                        new SQLiteParameter("@ISBN", isbn),
                        new SQLiteParameter("@Titulo", titulo),
                        new SQLiteParameter("@Autor", autor),
                        new SQLiteParameter("@Editorial", editorial),
                        new SQLiteParameter("@AnoPublicacion", anoPublicacion),
                        new SQLiteParameter("@Genero", genero),
                        new SQLiteParameter("@Copias", copias)
                    };

                    EjecutarComandoSql(query, parameters);

                    // Agregar el libro al DataGridView
                    dataGridView1.Rows.Add(isbn, titulo, autor, editorial, anoPublicacion, genero, copias);
                }
                else
                {
                    MessageBox.Show("Por favor ingrese un año de publicación y cantidad válidos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Debe completar todos los campos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Evento para eliminar un libro seleccionado
        private void ButtonEliminar_Click(object sender, EventArgs e)
        {
            // Verificar si se seleccionó alguna fila en el DataGridView
            if (dataGridView1.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                {
                    // Eliminar el libro de la base de datos
                    string isbn = row.Cells[0].Value.ToString();
                    string query = "DELETE FROM Libros WHERE ISBN = @ISBN";
                    SQLiteParameter[] parameters = { new SQLiteParameter("@ISBN", isbn) };

                    EjecutarComandoSql(query, parameters);

                    // Eliminar el libro del DataGridView
                    dataGridView1.Rows.RemoveAt(row.Index);
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar un libro para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Evento para editar un libro seleccionado
        private void ButtonEditar_Click(object sender, EventArgs e)
        {
            // Verificar si se seleccionó alguna fila en el DataGridView
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Obtener la fila seleccionada
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];

                // Usar el Prompt para editar los datos del libro
                string nuevoIsbn = Prompt.ShowDialog("Editar el ISBN del libro:", "Editar Libro", selectedRow.Cells[0].Value.ToString());
                string nuevoTitulo = Prompt.ShowDialog("Editar el título del libro:", "Editar Libro", selectedRow.Cells[1].Value.ToString());
                string nuevoAutor = Prompt.ShowDialog("Editar el autor del libro:", "Editar Libro", selectedRow.Cells[2].Value.ToString());
                string nuevaEditorial = Prompt.ShowDialog("Editar la editorial del libro:", "Editar Libro", selectedRow.Cells[3].Value.ToString());
                string nuevoAnoPublicacion = Prompt.ShowDialog("Editar el año de publicación:", "Editar Libro", selectedRow.Cells[4].Value.ToString());
                string nuevoGenero = Prompt.ShowDialog("Editar el género del libro:", "Editar Libro", selectedRow.Cells[5].Value.ToString());
                string nuevaCantidad = Prompt.ShowDialog("Editar la cantidad de copias:", "Editar Libro", selectedRow.Cells[6].Value.ToString());

                if (!string.IsNullOrEmpty(nuevoIsbn) && !string.IsNullOrEmpty(nuevoTitulo) && !string.IsNullOrEmpty(nuevoAutor) &&
                    !string.IsNullOrEmpty(nuevaEditorial) && !string.IsNullOrEmpty(nuevoAnoPublicacion) && !string.IsNullOrEmpty(nuevoGenero) && !string.IsNullOrEmpty(nuevaCantidad))
                {
                    // Actualizar los valores en el DataGridView
                    selectedRow.Cells[0].Value = nuevoIsbn;
                    selectedRow.Cells[1].Value = nuevoTitulo;
                    selectedRow.Cells[2].Value = nuevoAutor;
                    selectedRow.Cells[3].Value = nuevaEditorial;
                    selectedRow.Cells[4].Value = nuevoAnoPublicacion;
                    selectedRow.Cells[5].Value = nuevoGenero;
                    selectedRow.Cells[6].Value = nuevaCantidad;

                    // Actualizar en la base de datos SQLite
                    string query = "UPDATE Libros SET Titulo = @Titulo, Autor = @Autor, Editorial = @Editorial, AnoPublicacion = @AnoPublicacion, Genero = @Genero, Copias = @Copias WHERE ISBN = @ISBN";
                    SQLiteParameter[] parameters = {
                        new SQLiteParameter("@ISBN", nuevoIsbn),
                        new SQLiteParameter("@Titulo", nuevoTitulo),
                        new SQLiteParameter("@Autor", nuevoAutor),
                        new SQLiteParameter("@Editorial", nuevaEditorial),
                        new SQLiteParameter("@AnoPublicacion", nuevoAnoPublicacion),
                        new SQLiteParameter("@Genero", nuevoGenero),
                        new SQLiteParameter("@Copias", nuevaCantidad)
                    };

                    EjecutarComandoSql(query, parameters);
                }
                else
                {
                    MessageBox.Show("Debe completar todos los campos para editar el libro.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar un libro para editar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Evento que se ejecuta cuando se carga el formulario
        private void Libros_Load(object sender, EventArgs e)
        {
            // Llamar a la función para cargar los libros desde la base de datos
            CargarLibros();
        }
    }
}
