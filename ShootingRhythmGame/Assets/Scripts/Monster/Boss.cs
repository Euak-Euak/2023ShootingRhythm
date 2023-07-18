using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Boss : Attackable
{
    [SerializeField]
    private GameObject _bulletSprite;
    [SerializeField]
    private GameObject _laserSprite;
    public Transform _playerTransform;

    [SerializeField] protected Transform _leftEdge;
    [SerializeField] protected Transform _rightEdge;
    [SerializeField] protected Transform _upEdge;
    [SerializeField] protected Transform _downEdge;

    private void Awake()
    {
        base.Awake();
        _playerTransform = FindAnyObjectByType<PlayerMove>().GetComponent<Transform>();
        Attack();
    }
    public override void Dead()
    {
        gameObject.SetActive(false);
    }

    public virtual void Attack()
    {
        if (_hp / (float)_maxHp >= 0.5f)
            Phase1();
        else
            Phase2();

        Invoke("Attack", 5f);
    }
    public abstract void Phase1();
    public abstract void Phase2();

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
        laser.SetBulletData(_laserSprite);
        laser.Shoot(time, stayTime);
        return laser;
    }
}
