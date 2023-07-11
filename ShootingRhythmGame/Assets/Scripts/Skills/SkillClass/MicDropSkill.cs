using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MicDropSkill : PlayerSkill
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
        for (int i = 0; i < 5; i++)
        {
            StartCoroutine(FallDown(Shoot(transform.position, 3f, 0, _skillDamage)));
            yield return new WaitForSecondsRealtime(0.7f);
        }
        yield return null;
    }

    IEnumerator FallDown(Bullet bullet)
    {
        float t = 0;
        for (int i = 0; i < 7; i++)
        {
            while (t < 0.3f)
            {
                t += Time.deltaTime;
                yield return null;
                if (!bullet.gameObject.activeSelf)
                    yield break;
            }
            Shoot(bullet.transform.position, 4f, 180, _skillDamage);
            t = 0;
        }
        yield return null;
    }

    IEnumerator PowerUpSkill()
    {
        for (int i = 0; i < 7; i++)
        {
            StartCoroutine(FallDown2(Shoot(transform.position, 3f, 0, _skillDamage)));
            yield return new WaitForSecondsRealtime(0.5f);
        }
        yield return null;
    }

    IEnumerator FallDown2(Bullet bullet)
    {
        float t = 0;
        for (int i = 0; i < 7; i++)
        {
            while (t < 0.3f)
            {
                t += Time.deltaTime;
                yield return null;
                if (!bullet.gameObject.activeSelf)
                    yield break;
            }
            Shoot(bullet.transform.position, 4f, 180, _skillDamage);
            Shoot(bullet.transform.position, 4f, 160, _skillDamage);
            Shoot(bullet.transform.position, 4f, 200, _skillDamage);
            t = 0;
        }
        yield return null;
    }
}
