using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SQLiteWithConsoleApp
{
    public class SQLiteServices
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

        public void Update(SQLiteConnection connection)
        {
            string updateSql = "UPDATE users SET email = @newEmail WHERE name = @name";
            SQLiteCommand updateCommand = new SQLiteCommand(updateSql, connection);

            // Parameters
            updateCommand.Parameters.AddWithValue("@newEmail", "updated@example.com");
            updateCommand.Parameters.AddWithValue("@name", "John Doe");

            try
            {
                connection.Open();
                int rowsAffected = updateCommand.ExecuteNonQuery();
                Console.WriteLine($"Updated {rowsAffected} row(s)!");
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

        public void Delete(SQLiteConnection connection)
        {
            string deleteSql = "DELETE FROM users WHERE name = @name";
            SQLiteCommand deleteCommand = new SQLiteCommand(deleteSql, connection);

            // Parameter
            deleteCommand.Parameters.AddWithValue("@name", "John Doe");

            try
            {
                connection.Open();
                int rowsAffected = deleteCommand.ExecuteNonQuery();
                Console.WriteLine($"Deleted {rowsAffected} row(s)!");
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
