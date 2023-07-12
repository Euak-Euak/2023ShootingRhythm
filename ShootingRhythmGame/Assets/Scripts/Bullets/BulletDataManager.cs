using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDataManager : Singleton<BulletDataManager>
{
    private Dictionary<string, BulletData> _bulletData;

    void Start()
    {
        _bulletData = new Dictionary<string, BulletData>();
        GameObject[] data = Resources.LoadAll<GameObject>("BulletData");

        foreach (GameObject game in data)
        {
            BulletData bulletData = new BulletData();
            bulletData.Size = game.GetComponent<CapsuleCollider2D>();
            bulletData.Sprite = game.GetComponent<SpriteRenderer>().sprite;
            bulletData.IsPenetrate = game.GetComponent<BulletPenetrate>().IsPenetrate;

            _bulletData.Add(game.name, bulletData);
        }
    }

    public BulletData ReturnData(string name)
    {
        return _bulletData[name];
    }
}
