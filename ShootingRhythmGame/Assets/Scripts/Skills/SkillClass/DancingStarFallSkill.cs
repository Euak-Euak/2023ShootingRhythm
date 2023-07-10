using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DancingStarFallSkill : PlayerSkill
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
        Vector2[] bulletVector = new Vector2[3];
        bulletVector[0] = new Vector2(transform.position.x + 1.5f, transform.position.y);
        bulletVector[1] = new Vector2(transform.position.x, transform.position.y + 1.5f);
        bulletVector[2] = new Vector2(transform.position.x - 1.5f, transform.position.y);

        for (float t = 0; t < 2 * Mathf.PI; t += 0.05f * Mathf.PI)
        {
            float x = 5 * Mathf.Cos(2 * t) + 2 * Mathf.Cos(3 * t);
            float y = 2 * Mathf.Sin(3 * t) - 5 * Mathf.Sin(2 * t);

            Vector2 vector = new Vector2(x + transform.position.x, y + transform.position.y);
            Vector2 angle = (Vector2)transform.position - vector;
            float de = Mathf.Atan2(angle.y, angle.x) * Mathf.Rad2Deg + 90;
            float dis = Vector2.Distance(transform.position, vector);

            for (int i = 0; i < bulletVector.Length; i++)
            {
                Bullet bullet = Shoot(bulletVector[i], dis / 4, de, _skillDamage);
                StartCoroutine(NormalSkill_s(bullet));
            }
        }
        yield return null;
    }

    IEnumerator NormalSkill_s(Bullet bullet)
    {
        float t = 0;
        while (t <= 0.3f)
        {
            t += Time.deltaTime;
            yield return null;
            if (!bullet.gameObject.activeSelf)
                yield break;
        }
        bullet.Init(bullet.transform.position, 0, 0, _skillDamage);

        t = 0;
        while (t <= 0.4f)
        {
            t += Time.deltaTime;
            yield return null;
            if (!bullet.gameObject.activeSelf)
                yield break;
        }

        bullet.Init(bullet.transform.position, 5f, 0, _skillDamage);
        yield return null;
    }

    IEnumerator PowerUpSkill()
    {
        Vector2[] bulletVector = new Vector2[5];
        bulletVector[0] = new Vector2(transform.position.x + 1.5f, transform.position.y + 0.1f);
        bulletVector[1] = new Vector2(transform.position.x, transform.position.y + 1.5f);
        bulletVector[2] = new Vector2(transform.position.x - 1.5f, transform.position.y + 0.1f);
        bulletVector[3] = new Vector2(transform.position.x - 0.75f, transform.position.y - 1.7f);
        bulletVector[4] = new Vector2(transform.position.x + 0.75f, transform.position.y - 1.7f);

        for (float t = 0; t < 2 * Mathf.PI; t += 0.05f * Mathf.PI)
        {
            float x = 5 * Mathf.Cos(2 * t) + 2 * Mathf.Cos(3 * t);
            float y = 2 * Mathf.Sin(3 * t) - 5 * Mathf.Sin(2 * t);

            Vector2 vector = new Vector2(x + transform.position.x, y + transform.position.y);
            Vector2 angle = (Vector2)transform.position - vector;
            float de = Mathf.Atan2(angle.y, angle.x) * Mathf.Rad2Deg + 90;
            float dis = Vector2.Distance(transform.position, vector);

            for (int i = 0; i < bulletVector.Length; i++)
            {
                Bullet bullet = Shoot(bulletVector[i], dis / 4, de, _skillDamage);
                StartCoroutine(NormalSkill_s(bullet));
            }
        }
        yield return null;
    }
}
