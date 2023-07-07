using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Data;
using Mono.Data.Sqlite;
using System.IO;


public class TestClass : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void TestCode()
    {
        string filepath = "Data Source=" + Application.dataPath + "/Resources/Database/TestData.db;Pooling=true;FailIfMissing=false;Version=3";
        Debug.Log(filepath);    
        Debug.Log(File.Exists(filepath));

        try
        {
            IDbConnection conn = new SqliteConnection(filepath);
            conn.Open();

            Debug.Log(conn.State == ConnectionState.Open);

            IDbCommand cmd = conn.CreateCommand();
            cmd.CommandText = "Select Name From Test2 Where ID = '2'";

            IDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Debug.Log(reader.GetString(0));
            }


            reader.Dispose();
            cmd.Dispose();
            cmd = conn.CreateCommand();

            cmd.CommandText = "Update Test2 Set Name = '믕앵애' Where ID = '2'";
            reader = cmd.ExecuteReader();

            reader.Dispose();
            cmd.Dispose();
            cmd = conn.CreateCommand();

            cmd.CommandText = "Select Name From Test2 Where ID = '2'";
            reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Debug.Log(reader.GetString(0));
            }
            reader.Dispose();
            conn.Close();
        }
        catch (Exception e)
        {
            Debug.Log(e);
        }

    }
    

    public int Number(int id)
    {
        //conn.Open();

        int num = 4;//(어쩌구 ID로 불러온거 저장하기)

        //conn.Close();
        
        return num;
    }
}
