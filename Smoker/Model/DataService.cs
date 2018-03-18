using Mono.Data.Sqlite;
using System;
using System.Data.SqlClient;
using System.IO;
using System.Threading.Tasks;
using SQLite;

namespace Smoker.Model
{
    public class DataService : IDataService
    {
        string docsFolder;
        string pathToDatabase;
        string connectionString;

        const string TABLE_SMOKES = "smokes";

        private object _lock = new object();

        public void SetupDB()
        {
            lock (_lock)
            {
                try
                {
                    docsFolder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
                    pathToDatabase = Path.Combine(docsFolder, "db_smoker.db");

                    if (File.Exists(pathToDatabase))
                    {
                        SqliteConnection.CreateFile(pathToDatabase);
                        Console.WriteLine("[D] Database created under: " + pathToDatabase);
                    }
                    else
                    {
                        Console.WriteLine("[D] Database already present under: " + pathToDatabase); 
                    }

                }
                catch (IOException ex)
                {
                    Console.WriteLine(string.Format("[E] Failed to create Database - reason {0}", ex.Message));
                }
            }
        }

        public void CreateSmokesTable()
        {
            lock (_lock)
            {
                try
                {
                    // create a connection string for the database
                    connectionString = string.Format("Data Source={0};Version=3;", pathToDatabase);

                    using (var conn = new SqliteConnection((connectionString)))
                    {
                        conn.Open();
                        using (var command = conn.CreateCommand())
                        {
                            command.CommandText = $"CREATE TABLE {TABLE_SMOKES} (SmokeID INTEGER PRIMARY KEY AUTOINCREMENT, DateTime INTEGER)";
                            command.CommandType = System.Data.CommandType.Text;
                            command.ExecuteNonQuery();
                        }
                    }
                    Console.WriteLine("[D] Smokes table created.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(string.Format("[E] Failed to create Smokes table - reason = {0}", ex.Message));
                }
            }
        }

        public void InsertSmoke(DateTime time)
        {
            lock (_lock)
            {
                // create a connection string for the database
                connectionString = string.Format("Data Source={0};Version=3;", pathToDatabase);
                long unixTime = ((DateTimeOffset)time).ToUnixTimeSeconds();
                int res = 0;

                try
                {
                    using (var conn = new SqliteConnection((connectionString)))
                    {
                        conn.Open();
                        using (var command = conn.CreateCommand())
                        {
                            command.CommandText = $"INSERT INTO {TABLE_SMOKES} VALUES (null, {unixTime})";
                            command.CommandType = System.Data.CommandType.Text;
                            res = command.ExecuteNonQuery();
                        }
                    }
                    Console.WriteLine($"[D] {res} Smoke added to DB.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(string.Format("[E] Failed to insert into the database - reason = {0}", ex.Message));
                }
            }
        }

        public void GetSmokeCount()
        {
            int res = 0;
            lock (_lock)
            {
                // create a connection string for the database
                connectionString = string.Format("Data Source={0};Version=3;", pathToDatabase);

                try
                {
                    using (var conn = new SqliteConnection((connectionString)))
                    {
                        //SqliteCommand command = new SqliteCommand(
                        //  $"SELECT count(*) FROM {TABLE_SMOKES}",
                        //  conn);

                        conn.Open();
                        using (var command = conn.CreateCommand())
                        {
                            command.CommandText = $"SELECT * FROM Smokes";
                            command.CommandType = System.Data.CommandType.Text;

                            var reader = command.ExecuteReader();

                            while (reader.Read())
                            {
                                Console.WriteLine(String.Format("{0}", reader[0]));
                                JSONSerialize.
                            }
                            reader.Close();

                            //var x2 = command.ExecuteScalar();
                            //var x3 = command.ExecuteNonQuery();
                        }
                    }
                    Console.WriteLine("[D] SmokeTable created.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(string.Format("[E] Failed to get Smoke Count - reason = {0}", ex.Message));
                }
            }
        }

        public void GetData(Action<DataItem, Exception> callback)
        {
            // Use this to connect to the actual data service

            var item = new DataItem("Welcome to MVVM Light");
            callback(item, null);
        }
    }
}