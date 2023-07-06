public class CommandData : Data
{
    public CommandData()
    {
        _tableName = "From CommandTable";
    }

    public string NormalCommand(int ID)
    {
        string sql = $"Select Normal {_tableName} Where ID = '{ID}'";
        ExecuteSQL(sql);
        return reader.GetString(0);
    }

    public string PowerUpCommand(int ID)
    {
        string sql = $"Select PowerUp {_tableName} Where ID = '{ID}'";
        ExecuteSQL(sql);
        return reader.GetString(0);
    }
}