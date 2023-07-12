using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerSkill : MonoBehaviour
{
    [SerializeField]
    public Sprite _bulletSprite;

    public string _skillName;
    public string _skillImage;
    public string _commandNormal;
    public string _commandPowerUp;
    public int _skillDamage;
    public int _bulletType;
    public int _cooltimeBySkill;
    public float _cooltimeByTime;
    public bool _isPowerUp;

    public void Init(int ID)
    {
        _skillName = DataManager.Instance.SkillName(ID);
        _commandNormal = DataManager.Instance.CommandNormal(ID);
        _commandPowerUp = DataManager.Instance.CommandPowerUp(ID);
        _skillDamage = DataManager.Instance.SkillValue(ID);
        _bulletType = DataManager.Instance.BulletType(ID);
        _isPowerUp = DataManager.Instance.IsPowerUp(ID);
        _skillImage = DataManager.Instance.SkillImage(ID);
        _cooltimeBySkill = DataManager.Instance.CooltimeBySkill(ID);
        _cooltimeByTime = DataManager.Instance.CooltimeByTime(ID);
    }

    public Bullet Shoot(Vector3 pos, float speed, float angle, int damage, Sprite sprite = null)
    {
        Bullet bullet = BulletManager.Instance.SpawnObject();

        if (sprite == null)
            sprite = _bulletSprite;

        bullet.Init(pos, speed, angle, damage, LayerMask.NameToLayer("Monster"));
        return bullet;
    }

    public Laser Beam(Vector3 pos, float angle, int damage, float time, float stayTime, Sprite sprite = null)
    {
        Laser laser = LaserManager.Instance.SpawnObject();

        if (sprite == null)
            sprite = _bulletSprite;

        laser.Init(pos, angle, damage, sprite, LayerMask.NameToLayer("Monster"));
        laser.Shoot(time, stayTime);
        return laser;
    }

    public void SkillUse()
    {
        if (Input.GetKey(KeyCode.E))
        {
            SkillUsePowerUp();
        }
        else
        {
            SkillUseNormal();
        }
        return;

        if (_isPowerUp)
        {
            SkillUsePowerUp();
        }
        else
        {
            SkillUseNormal();
        }
    }

    protected abstract void SkillUseNormal();
    protected abstract void SkillUsePowerUp();
}
