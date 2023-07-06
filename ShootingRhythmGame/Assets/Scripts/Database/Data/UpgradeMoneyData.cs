public class UpgradeMoneyData : Data
{
    public UpgradeMoneyData()
    {
        _tableName = "From UpgradeMoneyTable";
    }

    public int SkillUpgradeMoney(int ID)
    {
        string sql = $"Select MoneyRequired From UpgradeMoneyTable Where Level = (Select SkillLevel From UserDataTable Where ID = {ID});";
        ExecuteSQL(sql);
        return reader.GetInt32(0);
    }
}