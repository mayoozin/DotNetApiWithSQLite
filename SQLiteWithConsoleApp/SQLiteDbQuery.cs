using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SQLiteWithConsoleApp
{
    public class SQLiteDbQuery
    {
        public void CreateTable(SQLiteConnection connection)
        {
            string createTableSql = "CREATE TABLE IF NOT EXISTS users (" +
    "id INTEGER PRIMARY KEY AUTOINCREMENT," +
    "name TEXT NOT NULL," +
    "email TEXT NOT NULL)";
            SQLiteCommand createTableCommand = new(createTableSql, connection);

            try
            {
                connection.Open();
                createTableCommand.ExecuteNonQuery();
                Console.WriteLine("Table created!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            finally
            {
                connection.Close();
            }

        }
        public void Insert(SQLiteConnection connection)
        {
            string insertSql = "INSERT INTO users (name, email) VALUES (@name, @email)";
            SQLiteCommand insertCommand = new SQLiteCommand(insertSql, connection);

            // Parameters
            insertCommand.Parameters.AddWithValue("@name", "John Doe");
            insertCommand.Parameters.AddWithValue("@email", "john@example.com");

            try
            {
                connection.Open();
                int rowsAffected = insertCommand.ExecuteNonQuery();
                Console.WriteLine($"Inserted {rowsAffected} row(s)!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            finally
            {
                connection.Close();
            }
        }

        public void Select(SQLiteConnection connection)
        {
            string query = "SELECT * FROM users";
            SQLiteCommand queryCommand = new SQLiteCommand(query, connection);

            try
            {
                connection.Open();
                SQLiteDataReader reader = queryCommand.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine($"ID: {reader["id"]}, Name: {reader["name"]}, Email: {reader["email"]}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
