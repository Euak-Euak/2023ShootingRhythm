using System;
using System.Collections.Generic;

[Serializable]
public class EnemyGameData
{
    public List<SecondEnemyData> EnemyDatas;

    public EnemyGameData()
    {
        EnemyDatas = new List<SecondEnemyData>();
    }
}
