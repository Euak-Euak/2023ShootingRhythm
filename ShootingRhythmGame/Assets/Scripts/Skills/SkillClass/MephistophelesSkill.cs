using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MephistophelesSkill : PlayerSkill
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

        bool LR = true;
        for (float i = -0.3f; i <= 0.3f; i += 0.2f)
        {
            for (float t = 0; t < 3.2f; t += 0.4f)
            {
                Vector2 vector = new Vector2(transform.position.x + i, transform.position.y + t);
                float dis = Vector2.Distance(transform.position, vector);
                float angle = Mathf.Atan2(transform.position.y - vector.y, transform.position.x - vector.x) * Mathf.Rad2Deg;
                Bullet bullet = Shoot(transform.position, dis * 3, angle + 90, _skillDamage);
                bullet.SetBulletData(Resources.Load<GameObject>($"BulletData/{_bulletType}"));
                StartCoroutine(Skill_s(bullet, LR));
                LR = !LR;
            }
        }

        yield return null;
    }
    IEnumerator Skill_s(Bullet bullet, bool LR)
    {
        float t = 0;
        while (t < 0.5f)
        {
            t += Time.deltaTime;
            yield return null;
            if (!bullet.gameObject.activeSelf)
                yield break;
        }
        if (LR)
        {
            bullet.Init(bullet.transform.position, 7f, 90, _skillDamage);
        }
        else
        {
            bullet.Init(bullet.transform.position, 7f, -90, _skillDamage);
        }

        yield return null;
    }

    IEnumerator PowerUpSkill()
    {
        bool LR = true;
        for (float i = -0.5f; i <= 0.5f; i += 0.2f)
        {
            for (float t = 0; t < 4.8f; t += 0.4f)
            {
                Vector2 vector = new Vector2(transform.position.x + i, transform.position.y + t);
                float dis = Vector2.Distance(transform.position, vector);
                float angle = Mathf.Atan2(transform.position.y - vector.y, transform.position.x - vector.x) * Mathf.Rad2Deg;
                Bullet bullet = Shoot(transform.position, dis * 3, angle + 90, _skillDamage);
                bullet.SetBulletData(Resources.Load<GameObject>($"BulletData/{_bulletType}"));
                StartCoroutine(Skill_s(bullet, LR));
                LR = !LR;
            }
        }
        yield return null;

    }
}
