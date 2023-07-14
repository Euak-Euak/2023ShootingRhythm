using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class JsonDataConvert : MonoBehaviour
{
    [SerializeField]
    MonsterManager _manager;
    void Start()
    {
        string filePath = Path.Combine(Application.streamingAssetsPath, "MyFile.sed");

        FileInfo fileInfo = new FileInfo(filePath);
        string value = "";

        if (fileInfo.Exists)
        {
            StreamReader reader = new StreamReader(filePath);
            value = reader.ReadToEnd();
            _manager.Init(JsonUtility.FromJson<EnemyGameData>(value));
            reader.Close();
        }
    }
}
