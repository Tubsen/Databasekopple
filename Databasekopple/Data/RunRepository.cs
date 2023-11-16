using Databasekopple.Models;
using SQLite;

namespace Databasekopple.Data
{
    // Represents a repository for managing run session data using SQLite
    public class RunRepository
    {
        // The path to the SQLite database file
        string _dbPath;

        // The SQLite database connection
        private SQLiteConnection _connection;

        // Constructor for creating a RunRepository instance with the specified database path
        public RunRepository(string dbPath)
        {
            _dbPath = dbPath;
        }

        // Initializes the database connection and creates the 'Run' table if it doesn't exist
        public void Init()
        {
            // Creates a new SQLite connection using the provided database path
            _connection = new SQLiteConnection(_dbPath);

            // Creates the 'Run' table if it doesn't exist
            _connection.CreateTable<Run>();
        }

        // Retrieves a list of all run sessions from the database
        public List<Run> GetAllRuns()
        {
            // Initializes the database connection
            Init();

            // Returns a list of all run sessions from the 'Run' table
            return _connection.Table<Run>().ToList();
        }

        // Adds a new run session to the database
        public void Add(Run run)
        {
            // Creates a new SQLite connection using the provided database path
            _connection = new SQLiteConnection(_dbPath);

            // Inserts the run session into the 'Run' table
            _connection.Insert(run);
        }

        // Deletes a run session from the database based on its ID
        public void Delete(int id)
        {
            // Creates a new SQLite connection using the provided database path
            _connection = new SQLiteConnection(_dbPath);

            // Deletes the run session with the specified ID from the 'Run' table
            _connection.Delete<Run>(id); // Use Delete<T> directly with the Id
        }
    }

}
