using System;
using System.Data.SQLite;
using System.Windows.Forms;

class Program
{
    static void Main()
    {
        string databasePath = "Data Source=biblioteca.db";

        // Crear una nueva conexión a la base de datos
        using (SQLiteConnection connection = new SQLiteConnection(databasePath))
        {
            connection.Open();

            // Crear tabla de libros
            string createBooksTableQuery = @"
                CREATE TABLE IF NOT EXISTS Libros (
                    ISBN TEXT PRIMARY KEY,
                    Titulo TEXT NOT NULL,
                    Autor TEXT NOT NULL,
                    Editorial TEXT NOT NULL,
                    AnoPublicacion INTEGER NOT NULL,
                    Genero TEXT NOT NULL,
                    Copias INTEGER NOT NULL
                );";

            using (SQLiteCommand command = new SQLiteCommand(createBooksTableQuery, connection))
            {
                command.ExecuteNonQuery();
            }

            // Crear tabla de usuarios
            string createUsersTableQuery = @"
                CREATE TABLE IF NOT EXISTS Usuarios (
                    ID INTEGER PRIMARY KEY AUTOINCREMENT,
                    Nombre TEXT NOT NULL,
                    Apellido TEXT NOT NULL,
                    Email TEXT NOT NULL,
                    Telefono TEXT NOT NULL
                );";

            using (SQLiteCommand command = new SQLiteCommand(createUsersTableQuery, connection))
            {
                command.ExecuteNonQuery();
            }

            // Crear tabla de reservas
            string createReservationsTableQuery = @"
                CREATE TABLE IF NOT EXISTS Reservas (
                    ID INTEGER PRIMARY KEY AUTOINCREMENT,
                    UsuarioID INTEGER NOT NULL,
                    ISBNLibro TEXT NOT NULL,
                    FechaReserva DATETIME DEFAULT CURRENT_TIMESTAMP,
                    FOREIGN KEY (UsuarioID) REFERENCES Usuarios(ID),
                    FOREIGN KEY (ISBNLibro) REFERENCES Libros(ISBN)
                );";

            using (SQLiteCommand command = new SQLiteCommand(createReservationsTableQuery, connection))
            {
                command.ExecuteNonQuery();
            }

            Console.WriteLine("Database and tables created successfully.");
        }

        // Abrir la aplicación de Windows Forms (Form1)
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        Application.Run(new Library.Form1()); // Asegúrate de que el namespace y el formulario sean correctos
    }
}
