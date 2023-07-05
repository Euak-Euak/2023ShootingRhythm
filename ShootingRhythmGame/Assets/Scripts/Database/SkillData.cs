public class SkillData : Data
{
    public SkillData()
    {
        _tableName = "From SkillDataTable";
    }

    public string SkillName(int ID)
    {
        string sql = $"Select Name {_tableName} Where ID = '{ID}'";
        ExecuteSQL(sql);
        return reader.GetString(0);
    }

    public string SkillDescript(int ID)
    {
        string sql = $"Select Descript {_tableName} Where ID = '{ID}'";
        ExecuteSQL(sql);
        return reader.GetString(0);
    }

    public string UseSkillDescript(int ID)
    {
        string sql = $"Select SkillUseDescript {_tableName} Where ID = '{ID}'";
        ExecuteSQL(sql);
        return reader.GetString(0);
    }
    public string UsePowerUpSkillDescript(int ID)
    {
        string sql = $"Select PowerUpDescript {_tableName} Where ID = '{ID}'";
        ExecuteSQL(sql);
        return reader.GetString(0);
    }
    public string SkillImage(int ID)
    {
        string sql = $"Select Image {_tableName} Where ID = '{ID}'";
        ExecuteSQL(sql);
        return reader.GetString(0);
    }
}
