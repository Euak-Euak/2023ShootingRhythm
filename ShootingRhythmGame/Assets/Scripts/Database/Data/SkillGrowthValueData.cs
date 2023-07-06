using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillGrowthValueData : Data
{
    public SkillGrowthValueData()
    {
        _tableName = "From SkillGrowthValueTable";
    }

    public int InitValue(int ID)
    {
        string sql = $"Select InitValue {_tableName} Where ID = '{ID}'";
        ExecuteSQL(sql);
        return reader.GetInt32(0);
    }

    public int GrowthValue(int ID)
    {
        string sql = $"Select GrowthValue {_tableName} Where ID = '{ID}'";
        ExecuteSQL(sql);
        return reader.GetInt32(0);
    }
}
