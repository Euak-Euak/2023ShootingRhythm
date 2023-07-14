using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterManager : ObjectPooling<Monster>
{
    EnemyGameData _enemyGameData;

    private List<Vector2> _transform;
    
    [SerializeField]
    private Transform _start;
    [SerializeField]
    private Transform _end;

    [SerializeField]
    private Vector2 _gap;

    [SerializeField]
    private List<GameObject> _monsters;

    private void Start()
    {
        base.Start();
        _gap = (_end.position - _start.position) / 6;

        _transform = new List<Vector2>();

        for (int i = 1; i <= 5; i++)
            _transform.Add(new Vector2(_start.position.x + _gap.x * i, _end.position.y));
        for (int i = 1; i <= 5; i++)
            _transform.Add(new Vector2(_end.position.x, _start.position.y + _gap.y * i));
        for (int i = 1; i <= 5; i++)
            _transform.Add(new Vector2(_start.position.x + _gap.x * i, _start.position.y));
        for (int i = 1; i <= 5; i++)
            _transform.Add(new Vector2(_start.position.x, _start.position.y + _gap.y * i));
    }

    public void Init(EnemyGameData data)
    {
        _enemyGameData = data;
        StartCoroutine(GameStart());
    }

    public IEnumerator GameStart()
    {
        WaitForSecondsRealtime wait = new WaitForSecondsRealtime(1f);

        foreach (SecondEnemyData data in _enemyGameData.EnemyDatas)
        {
            foreach (EnemyData enemyData in data.EnemyDatas)
            {
                Monster monster = SpawnObject();
                monster.Init(enemyData, _start.position + new Vector3(_gap.x * enemyData.HandleX, _gap.y * enemyData.HandleY));
                monster.gameObject.SetActive(true);
                monster.Move(_transform[enemyData.StartPosition - 1], _transform[enemyData.EndPosition - 1]);
            }
            yield return wait;
        }
    }
}

