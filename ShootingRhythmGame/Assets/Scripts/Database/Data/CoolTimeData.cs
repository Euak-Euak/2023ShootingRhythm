public class CoolTimeData : Data
{
    public CoolTimeData()
    {
        _tableName = "From CoolTimeTable";
    }

    public int SkillCountCool(int ID)
    {
        string sql = $"Select SkillCount {_tableName} Where ID = '{ID}'";
        ExecuteSQL(sql);
        return reader.GetInt32(0);
    }

    public float RealTimeCool(int ID)
    {
        string sql = $"Select RealTime {_tableName} Where ID = '{ID}'";
        ExecuteSQL(sql);
        return reader.GetFloat(0);
    }
}