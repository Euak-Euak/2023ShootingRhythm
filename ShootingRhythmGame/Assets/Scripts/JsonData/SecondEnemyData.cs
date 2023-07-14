using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class SecondEnemyData
{
    public int Second;
    public List<EnemyData> EnemyDatas;

    public SecondEnemyData(int second)
    {
        EnemyDatas = new List<EnemyData>();
        Second = second;
    }
}
