using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using UnityEngine;

public class MonsterManager : ObjectPooling<Monster>
{
    EnemyGameData _enemyGameData;

    public Transform _playerTransform;

    private List<Vector2> _transform;
    
    [SerializeField]
    private Transform _start;
    [SerializeField]
    private Transform _end;

    [SerializeField]
    private Vector2 _gap;

    [SerializeField]
    private List<GameObject> _monsters;

    [SerializeField]
    private BossController _boss;

    private Dictionary<EnemyType, Queue<Monster>> _monster;

    private void Start()
    {
        base.Start();
        _gap = (_end.position - _start.position) / 6;
        _monster = new Dictionary<EnemyType, Queue<Monster>>();
        for (int i = 0; i < (int)EnemyType.Monter43; i++)
            _monster[(EnemyType)i] = new Queue<Monster>();
        
        _transform = new List<Vector2>();

        for (int i = 1; i <= 5; i++)
            _transform.Add(new Vector2(_start.position.x + _gap.x * i, _end.position.y));
        for (int i = 1; i <= 5; i++)
            _transform.Add(new Vector2(_end.position.x, _start.position.y + _gap.y * i));
        for (int i = 1; i <= 5; i++)
            _transform.Add(new Vector2(_start.position.x + _gap.x * i, _start.position.y));
        for (int i = 1; i <= 5; i++)
            _transform.Add(new Vector2(_start.position.x, _start.position.y + _gap.y * i));

        switch (PlayerDataManager.Instance.RoundType)
        {
            case GameRoundType.Stage1Boss:
            case GameRoundType.Stage2Boss:
            case GameRoundType.Stage3Boss:
            case GameRoundType.Stage4Boss:
            case GameRoundType.Stage5Boss:
            case GameRoundType.LastBoss:
                _boss.Spawn();
                break;
            case GameRoundType.Stage1Field:
            case GameRoundType.Stage2Field:
            case GameRoundType.Stage3Field:
            case GameRoundType.Stage4Field:
            case GameRoundType.Stage5Field:
                Init(Convert());
                break;
        }
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
                Monster monster = Spwan(enemyData.EnemyType);
                monster.Init(enemyData, _start.position + new Vector3(_gap.x * enemyData.HandleX, _gap.y * enemyData.HandleY));
                monster.gameObject.SetActive(true);
                monster.Move(_transform[enemyData.StartPosition - 1], _transform[enemyData.EndPosition - 1]);
            }
            yield return wait;
        }

        Invoke("D", 3f);
    }

    public void D()
    {
        SceneLoadManager.LoadScene("ShopScene");
    }

    private EnemyGameData Convert()
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

    public Monster Spwan(EnemyType enemyType)
    {
        if (_poolingObjects.Count == 0)
        {
            Monster o = Instantiate(_monsters[(int)enemyType], _parent).GetComponent<Monster>();
            return o;
        }

        Monster p = _monster[enemyType].Dequeue();
        return p;
    }

    public override void ReturnObject(Monster p)
    {
        _monster[p.GetMonsterType()].Enqueue(p);
    }
}

