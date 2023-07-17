using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class JsonDataConvert : MonoBehaviour
{
    public EnemyGameData Convert()
    {
        string filePath = Path.Combine(Application.streamingAssetsPath, "MyFile.sed");

        FileInfo fileInfo = new FileInfo(filePath);
        string value = "";

        if (fileInfo.Exists)
        {
            StreamReader reader = new StreamReader(filePath);
            value = reader.ReadToEnd();
            reader.Close();
            return JsonUtility.FromJson<EnemyGameData>(value);
        }

        return null;
    }
}
