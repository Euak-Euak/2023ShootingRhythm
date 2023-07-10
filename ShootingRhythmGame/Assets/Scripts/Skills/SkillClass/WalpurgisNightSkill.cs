using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalpurgisNightSkill : PlayerSkill
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
        for (int i = 0; i < 360; i+= 10)
        {
            Bullet bullet = Shoot(transform.position, 5, i, _skillDamage);
            StartCoroutine(RandShoot(bullet, i));
        }
        yield return null;
    }

    IEnumerator RandShoot(Bullet bullet, int angle)
    {
        float t = 0;
        while (t >= 2f)
        {

        }
        yield return null;
    }

    IEnumerator PowerUpSkill()
    {

        yield return null;
    }
}
