using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LudditeMoveSkill : PlayerSkill
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
        Bullet bullet = Shoot(transform.position, 2.5f, 0, _skillDamage);

        float t = 0f;

        while (t < 1f)
        {
            t += Time.deltaTime;
            yield return null;
            if (!bullet.gameObject.activeSelf)
                yield break;
        }

        bullet.gameObject.SetActive(false);

        for (int j = 0; j < 2; j++)
        {
            for (int i = 0; i <= 360; i += 5)
            {
                Shoot(bullet.transform.position, 5f, i, _skillDamage);
                Shoot(bullet.transform.position, 5f, i + 180, _skillDamage);
                yield return new WaitForSecondsRealtime(0.001f);
            }
        }
        yield return null;
    }

    IEnumerator PowerUpSkill()
    {
        Bullet bullet = Shoot(transform.position, 2.5f, 0, _skillDamage);

        float t = 0f;

        while (t < 1f)
        {
            t += Time.deltaTime;
            yield return null;
            if (!bullet.gameObject.activeSelf)
                yield break;
        }

        bullet.gameObject.SetActive(false);

        for (int j = 0; j < 4; j++)
        {
            for (int i = 0; i <= 360; i += 5)
            {
                Shoot(bullet.transform.position, 5f, i, _skillDamage);
                Shoot(bullet.transform.position, 5f, i + 90, _skillDamage);
                Shoot(bullet.transform.position, 5f, i + 180, _skillDamage);
                Shoot(bullet.transform.position, 5f, i + 270, _skillDamage);
                yield return new WaitForSecondsRealtime(0.001f);
            }
        }
        yield return null;
    }
}
