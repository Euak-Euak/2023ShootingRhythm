public class UserData : Data
{
    public UserData()
    {
        _tableName = "UserDataTable";
    }

    public int GetSkillLevel(int ID)
    {
        string sql = $"Select SkillLevel From {_tableName} Where ID = '{ID}'";
        ExecuteSQL(sql);
        return reader.GetInt32(0);
    }

    public bool GetPowerUp(int ID)
    {
        string sql = $"Select PowerUp From {_tableName} Where ID = '{ID}'";
        ExecuteSQL(sql);
        return reader.GetInt32(0) == 1;
    }

    public void SetSkillLevel(int ID, int skillLevel)
    {
        string sql = $"Update {_tableName} Set SkillLevel = {skillLevel} Where ID = '{ID}'";
        ExecuteSQL(sql);
    }

    public void SetPowerUp(int ID, bool powerUp)
    {
        int boolToInt;
        if (powerUp)
            boolToInt = 1;
        else
            boolToInt = 0;

        string sql = $"Update {_tableName} Set PowerUp = {boolToInt} Where ID = '{ID}'";
        ExecuteSQL(sql);
    }
}