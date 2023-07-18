using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CustomNamespace;

public abstract class Monster : Attackable
{
    [SerializeField]
    private GameObject _bulletSprite;

    private EnemyData _enemyData;
    private Vector2 _handle;

    public override void Dead()
    {
        MonsterManager.Instance.ReturnObject(this);
        ItemManager.Instance.Equals(this);
        gameObject.SetActive(false);
    }

    public abstract void Attack();

    public Bullet Shoot(Vector3 pos, float speed, float angle, int damage)
    {
        Bullet bullet = BulletManager.Instance.SpawnObject();
        bullet.tag = "Monster";
        bullet.SetBulletData(_bulletSprite);
        
        bullet.Init(pos, speed, angle, damage, LayerMask.NameToLayer("Player"));
        return bullet;
    }

    public Laser Beam(Vector3 pos, float angle, int damage, float time, float stayTime, Sprite sprite = null)
    {
        Laser laser = LaserManager.Instance.SpawnObject();

        laser.Init(pos, angle, damage, sprite, LayerMask.NameToLayer("Player"));
        laser.Shoot(time, stayTime);
        return laser;
    }

    public virtual void Init(EnemyData enemy, Vector2 handle)
    {
        _enemyData = enemy;
        _handle = handle;
    }

    public void Move(Vector2 pos1, Vector2 pos2)
    {
        StartCoroutine(MoveCoroutine(pos1, pos2));
        StartCoroutine(AttackCoroutine());
    }

    private IEnumerator AttackCoroutine()
    {
        yield return new WaitForSeconds(_enemyData.BulletShootTime);
        Attack();
    }

    private IEnumerator MoveCoroutine(Vector2 pos1, Vector2 pos2)
    {
        float t = 0f;

        while (t < _enemyData.StopTime)
        {
            t += Time.deltaTime;
            transform.position = pos1.GetBezierPosition(_handle, _handle, pos2, t / _enemyData.MoveTime);
            yield return null;
        }

        yield return new WaitForSeconds(_enemyData.DelayTime);

        while (t < _enemyData.MoveTime)
        {
            t += Time.deltaTime;
            transform.position = pos1.GetBezierPosition(_handle, _handle, pos2, t / _enemyData.MoveTime);
            yield return null;
        }

        gameObject.SetActive(false);
        MonsterManager.Instance.ReturnObject(this);
    }
}
