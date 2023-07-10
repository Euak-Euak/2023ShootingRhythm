using System.Collections;
using System.Collections.Generic;
using System.Data;
using Mono.Data.Sqlite;
using UnityEngine;

public class Data
{
    protected IDbConnection conn;
    protected IDbCommand cmd;
    protected IDataReader reader;

    protected string _tableName;

    public Data()
    {
        string filepath = "Data Source=" + Application.dataPath + "/Resources/Database/SkillData.db;Pooling=true;FailIfMissing=false;Version=3";
        conn = new SqliteConnection(filepath);
    }

    protected void ExecuteSQL(string sql)
    {
        cmd = conn.CreateCommand();
        cmd.CommandText = sql;
        reader = cmd.ExecuteReader();
        cmd.Dispose();
        reader.Read();
    }

    public void Open()
    {
        conn.Open();
    }
    public void Close()
    {
        conn.Close();
    }
}