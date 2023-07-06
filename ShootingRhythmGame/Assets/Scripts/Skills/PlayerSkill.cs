using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerSkill : MonoBehaviour
{
    [SerializeField]
    private Sprite _bulletSprite;

    public Bullet Shoot(Vector3 pos, float speed, float angle, int damage, Sprite sprite = null)
    {
        Bullet bullet = BulletManager.Instance.SpawnObject();

        if (sprite == null)
            sprite = _bulletSprite;

        bullet.Init(pos, speed, angle, damage, sprite, LayerMask.NameToLayer("Monster"));
        return bullet;
    }

    public abstract void SkillUse();
}
