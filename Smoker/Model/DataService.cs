using Mono.Data.Sqlite;
using System;
using System.Data.SqlClient;
using System.IO;
using System.Threading.Tasks;
using SQLite;
using smoker.Model;
using SQLite.Net;
using System.Collections.Generic;

namespace Smoker.Model
{
    public class DataService : IDataService
    {
        string docsFolder;
        string pathToDatabase;
        string connectionString;

        const string DB_NAME = "db_smoker.db";
        const string TABLE_SMOKES = "smokes";

        SQLiteConnection _db;

        private object _lock = new object();

        public void SetupDB()
        {
            lock (_lock)
            {
                try
                {
                    // Get folder for DB
                    docsFolder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
                    pathToDatabase = Path.Combine(docsFolder, DB_NAME);

                    // Check if DB already exists
                    if (File.Exists(pathToDatabase))
                    {
                        Console.WriteLine("[D] Database created under: " + pathToDatabase);
                    }
                    else
                    {
                        Console.WriteLine("[D] Database already present under: " + pathToDatabase);
                    }

                    // Get/Create DB
                    _db = new SQLiteConnection(new SQLite.Net.Platform.XamarinAndroid.SQLitePlatformAndroid(), pathToDatabase);
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
                    _db.CreateTable<Smoke>();
                    Console.WriteLine("[D] Smokes table created.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(string.Format("[E] Failed to create Smokes table - reason = {0}", ex.Message));
                }
            }
        }

        public void InsertSmoke(DateTime time, Action<Exception> callback)
        {
            lock (_lock)
            {
                try
                {
                    long unixTime = ((DateTimeOffset)time).ToUnixTimeSeconds();

                    _db.Insert(new Smoke(0, unixTime));

                    Console.WriteLine($"[D] Smoke added to DB.");

                    callback(null);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(string.Format("[E] Failed to insert into the database - reason = {0}", ex.Message));
                    callback(ex);
                }
            }
        }

        public void GetSmokeCount(Action<int, Exception> callback)
        {
            lock (_lock)
            {
                try
                {
                    var count = _db.Table<Smoke>()?.Count() ?? 0;
                    Console.WriteLine($"[D] {count} smokes in DB.");
                    callback(count, null);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(string.Format("[E] Failed to get Smoke Count - reason = {0}", ex.Message));
                    callback(0, ex);
                }
            }
        }

        public void GetSmokes(Action<List<Smoke>, Exception> callback)
        {
            lock (_lock)
            {
                // create a connection string for the database
                connectionString = string.Format("Data Source={0};Version=3;", pathToDatabase);

                try
                {
                    var conn = _db.Table<Smoke>();

                    List<Smoke> smokes = null;
                    foreach(var smo in conn)
                    {
                        smokes.Add(new Smoke(smo.Id,smo.Time));
                    }

                    Console.WriteLine("[D] SmokeTable created.");
                    callback(smokes, null);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(string.Format("[E] Failed to get Smoke Count - reason = {0}", ex.Message));
                    callback(null, ex);
                }
            }
        }

    }
}