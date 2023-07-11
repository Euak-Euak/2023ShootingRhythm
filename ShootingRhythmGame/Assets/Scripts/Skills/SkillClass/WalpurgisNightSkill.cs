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
        for (int i = 0; i < 360; i+= 5)
        {
            Bullet bullet = Shoot(transform.position, 20, i, _skillDamage);
            StartCoroutine(RandShoot(bullet, i, 3));
        }
        yield return null;
    }

    IEnumerator RandShoot(Bullet bullet, int angle, int repeat)
    {
        bool Rn = false;

        float t = 0;
        while (t <= 0.05f)
        {
            t += Time.deltaTime;
            yield return null;
            if (!bullet.gameObject.activeSelf)
                yield break;
        }
        bullet.Init(bullet.transform.position, 0, angle, _skillDamage);

        for (int i = 0; i < repeat; i++)
        {
            t = 0;
            while (t <= 1f)
            {
                t += Time.deltaTime;
                yield return null;
                if (!bullet.gameObject.activeSelf)
                    yield break;
            }

            if (Rn)
            {
                Shoot(bullet.transform.position, 6, Random.Range(0, 360), _skillDamage);
            }
            else
            {
                Shoot(bullet.transform.position, 6, angle, _skillDamage);
            }
            Rn = !Rn;
        }

        bullet.gameObject.SetActive(false);

        yield return null;
    }

    IEnumerator PowerUpSkill()
    {
        for (int i = 0; i < 360; i += 5)
        {
            Bullet bullet = Shoot(transform.position, 20, i, _skillDamage);
            Bullet bullet2 = Shoot(transform.position, 30, i, _skillDamage);
            StartCoroutine(RandShoot(bullet, i, 5));
            StartCoroutine(RandShoot(bullet2, i, 4));
        }
        yield return null;
    }
}
