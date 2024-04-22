using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetApiWithSQLite.DbServices
{
    public class SQLiteDbContextService
    {
        private readonly SQLiteConnection _connection;

        public SQLiteDbContextService(string connectionString)
        {
            _connection = new SQLiteConnection(connectionString);
        }

        public List<T> Query<T>(string query, object? parameters = null)
        {
            SQLiteCommand cmd = new SQLiteCommand(query, _connection);
            _connection.Open();
            if (parameters != null)
            {
                cmd.Parameters.AddRange(GetParameters(parameters).ToArray());
            }
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            _connection.Close();

            var lst = JsonConvert.DeserializeObject<List<T>>(JsonConvert.SerializeObject(dt));
            return lst!;
        }

        public int Execute(string query, object? parameters = null)
        {
            SQLiteCommand cmd = new SQLiteCommand(query, _connection);
            _connection.Open();
            if (parameters != null)
            {
                cmd.Parameters.AddRange(GetParameters(parameters).ToArray());
            }
            var result = cmd.ExecuteNonQuery();
            _connection.Close();
            return result;
        }

        public async Task<int> ExecuteAsync(string query, object? parameters = null)
        {
            await _connection.OpenAsync();
            try
            {
                using (SQLiteCommand cmd = new SQLiteCommand(query, _connection))
                {
                    if (parameters != null)
                    {
                        cmd.Parameters.AddRange(GetParameters(parameters).ToArray());
                    }
                    var result = await cmd.ExecuteNonQueryAsync();
                    return result;
                }
            }
            finally
            {
                await _connection.CloseAsync();
            }
        }


        public List<SQLiteParameter> GetParameters<T>(T obj)
        {
            List<SQLiteParameter> sQLiteParameters = new List<SQLiteParameter>();
            foreach (var property in obj.GetType().GetProperties())
            {
                sQLiteParameters.Add(new SQLiteParameter(property.Name, property.GetValue(obj) ?? DBNull.Value));
            }
            return sQLiteParameters;
        }
    }
}
