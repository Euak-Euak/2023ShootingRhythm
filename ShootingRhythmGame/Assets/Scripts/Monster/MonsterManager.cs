//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class MonsterManager : ObjectPooling<Monster>
//{
//    EnemyGameData _enemyGameData;

//    [SerializeField]
//    private List<Transform> _transform;

//    [SerializeField]
//    private List<GameObject> _monsters;

//    public void Init(EnemyGameData data)
//    {
//        _enemyGameData = data;
//        StartCoroutine(GameStart());
//    }

//    public IEnumerator GameStart()
//    {
//        WaitForSecondsRealtime wait = new WaitForSecondsRealtime(1f);

//        foreach (SecondEnemyData data in _enemyGameData.EnemyDatas)
//        {
//            foreach (EnemyData enemyData in data.EnemyDatas)
//            {
//                Monster monster = SpawnObject(_monsters[(int)enemyData.EnemyType]);
//                monster.Init(enemyData);
//                monster.Move(_transform[enemyData.StartPosition - 1].position, _transform[enemyData.EndPosition - 1].position);
//            }
//            yield return wait;
//        }
//    }
//}

