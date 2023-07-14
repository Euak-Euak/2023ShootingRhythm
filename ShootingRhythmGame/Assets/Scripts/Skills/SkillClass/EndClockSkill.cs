using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndClockSkill : PlayerSkill
{
    protected override void SkillUseNormal()
    {
        StartCoroutine(NormalSkill());
    }

    protected override void SkillUsePowerUp()
    {
        StartCoroutine(PowerUpSkill());
    }

    IEnumerator NormalSkill()
    {
        Laser laser = Beam(transform.position, 0, _skillDamage, 0.3f, 4f);
        laser.SetBulletData(Resources.Load<GameObject>($"BulletData/{_bulletType}"));

        for (int i = 0; i < 360; i++)
        {
            laser.Init(laser.transform.position, i, _skillDamage);
            yield return new WaitForSecondsRealtime(0.01f);
        }
        yield return null;
    }

    IEnumerator PowerUpSkill()
    {
        Laser laser = Beam(transform.position, 0, _skillDamage, 0.3f, 4f);
        Laser laser2 = Beam(transform.position, 0, _skillDamage, 0.3f, 4f);
        laser.SetBulletData(Resources.Load<GameObject>($"BulletData/{_bulletType}"));
        laser2.SetBulletData(Resources.Load<GameObject>($"BulletData/{_bulletType2}"));

        for (int i = 0; i < 360; i++)
        {
            laser.Init(laser.transform.position, i, _skillDamage);
            laser2.Init(laser.transform.position, i * 2, _skillDamage);
            yield return new WaitForSecondsRealtime(0.01f);
        }
        yield return null;
    }
}
