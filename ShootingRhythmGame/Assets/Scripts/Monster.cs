using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Monster : Attackable
{
    [SerializeField]
    private GameObject _bulletSprite;

    private EnemyData _enemyData;
    private Vector2 _handle;

    public override void Dead()
    {
        gameObject.SetActive(false);
    }

    public abstract void Attack();

    public Bullet Shoot(Vector3 pos, float speed, float angle, int damage)
    {
        Bullet bullet = BulletManager.Instance.SpawnObject();
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

    public void Init(EnemyData enemy, Vector2 handle)
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
            transform.position = GetBezierPosition(pos1, _handle, _handle, pos2, t / _enemyData.MoveTime);
            yield return null;
        }

        yield return new WaitForSeconds(_enemyData.DelayTime);

        while (t < _enemyData.MoveTime)
        {
            t += Time.deltaTime;
            transform.position = GetBezierPosition(pos1, _handle, _handle, pos2, t / _enemyData.MoveTime);
            yield return null;
        }

        gameObject.SetActive(false);
        MonsterManager.Instance.ReturnObject(this);
    }

    private Vector3 GetBezierPosition(Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3, float t)
    {
        Vector3 q0 = Vector3.Lerp(p0, p1, t);
        Vector3 q1 = Vector3.Lerp(p1, p2, t);
        Vector3 q2 = Vector3.Lerp(p2, p3, t);

        Vector3 r0 = Vector3.Lerp(q0, q1, t);
        Vector3 r1 = Vector3.Lerp(q1, q2, t);

        return Vector3.Lerp(r0, r1, t);
    }
}
