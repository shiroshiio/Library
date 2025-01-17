using System;
using System.Data.SQLite;

public class DBHelper
{
    private static string connectionString = "Data Source=biblioteca.db;Version=3;";

    public static SQLiteConnection GetConnection()
    {
        return new SQLiteConnection(connectionString);
    }

    public static void ExecuteNonQuery(string query)
    {
        using (var conn = GetConnection())
        {
            conn.Open();
            using (var cmd = new SQLiteCommand(query, conn))
            {
                cmd.ExecuteNonQuery();
            }
        }
    }

    public static SQLiteDataReader ExecuteQuery(string query)
    {
        SQLiteConnection conn = GetConnection();
        conn.Open();
        SQLiteCommand cmd = new SQLiteCommand(query, conn);
        return cmd.ExecuteReader();
    }
}
