// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

using SQLiteWithConsoleApp;
using System;
using System.Data;
using System.Data.SQLite;

class Program
{
    static void Main()
    {
        string connectionString = "Data Source=mydatabase.db;Version=3;";
        SQLiteConnection connection = new(connectionString);

        try
        {
            connection.Open();
            Console.WriteLine("Connected to SQLite Database!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
        finally
        {
            connection.Close();
        }

        SQLiteServices sQLiteDbQuery = new SQLiteServices();
        sQLiteDbQuery.CreateTable(connection);
        sQLiteDbQuery.Insert(connection);
        sQLiteDbQuery.Select(connection);
        sQLiteDbQuery.Update(connection);
        sQLiteDbQuery.Delete(connection);

    }
}
