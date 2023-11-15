using Databasekopple.Models;
using SQLite;

namespace Databasekopple.Data
{
    public class RunRepository
    {
        string _dbPath;
        private SQLiteConnection _connection;

        public RunRepository(string dbPath)
        {
            _dbPath = dbPath;
        }

        public void Init()
        {
            _connection = new SQLiteConnection(_dbPath);
            _connection.CreateTable<Run>();
        }

        public List<Run> GetAllRuns()
        {
            Init();
            return _connection.Table<Run>().ToList();
        }

        public void Add(Run run)
        {
            _connection = new SQLiteConnection( _dbPath);
            _connection.Insert(run);
        }

        public void Delete(int id)
        {
            _connection = new SQLiteConnection(_dbPath);
            _connection.Delete<Run>(id); // Use Delete<T> directly with the Id
        }
    }
}
