public class Orm
{
    readonly Database _database;

    public Orm(Database database) => _database = database;
    
    public void Write(string data)
    {
        try
        {
            _database.BeginTransaction();
            _database.Write(data);
            _database.EndTransaction();
        }
        catch
        {
            _database.Dispose();
            throw;
        }
    }

    public bool WriteSafely(string data)
    {
        try
        {
            _database.BeginTransaction();
            _database.Write(data);
            _database.EndTransaction();
        }
        catch
        {
            _database.Dispose();
            return false;
        }
        return true;
    }
}
