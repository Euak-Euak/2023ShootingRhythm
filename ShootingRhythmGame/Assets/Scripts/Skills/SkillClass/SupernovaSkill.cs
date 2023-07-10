using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SupernovaSkill : PlayerSkill
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
        for (float t = 0; t < 2 * Mathf.PI; t += 0.05f * Mathf.PI)
        {
            float x = 5 * Mathf.Cos(2 * t) + 2 * Mathf.Cos(3 * t);
            float y = 2 * Mathf.Sin(3 * t) - 5 * Mathf.Sin(2 * t);

            Vector2 vector = new Vector2(x + transform.position.x, y + transform.position.y);
            Vector2 angle = (Vector2)transform.position - vector;
            float de = Mathf.Atan2(angle.y, angle.x) * Mathf.Rad2Deg + 90;
            float dis = Vector2.Distance(transform.position, vector);

            Bullet bullet = Shoot(transform.position, dis / 3, de, _skillDamage);
            StartCoroutine(ShrinkAndBoom(bullet, de, dis / 3, false));
        }
        yield return null;
    }

    IEnumerator ShrinkAndBoom(Bullet bullet, float angle, float speed, bool isPowerUp)
    {
        float t = 0;
        while ( t <= 1f )
        {
            t += Time.deltaTime;
            yield return null;
            if (!bullet.gameObject.activeSelf)
                yield break;
        }
        angle -= 180;
        bullet.Init(bullet.transform.position, speed * 5, angle, _skillDamage);

        t = 0;
        while (t <= 0.2f)
        {
            t += Time.deltaTime;
            yield return null;
            if (!bullet.gameObject.activeSelf)
                yield break;
        }

        float randAngle = Random.Range(0.0f, 360.0f);

        Vector2 vector = bullet.transform.position;

        bullet.gameObject.SetActive(false);
        Shoot(vector, Random.Range(8.0f, 15.0f), randAngle, _skillDamage);
        Shoot(vector, Random.Range(8.0f, 15.0f), randAngle + 180, _skillDamage);

        if (isPowerUp)
        {
            yield return new WaitForSecondsRealtime(1f);
            Shoot(vector, Random.Range(8.0f, 15.0f), randAngle, _skillDamage);
            Shoot(vector, Random.Range(8.0f, 15.0f), randAngle + 180, _skillDamage);
        }

        yield return null;
    }

    IEnumerator PowerUpSkill()
    {
        for (float t = 0; t < 2 * Mathf.PI; t += 0.05f * Mathf.PI)
        {
            float x = 5 * Mathf.Cos(2 * t) + 2 * Mathf.Cos(3 * t);
            float y = 2 * Mathf.Sin(3 * t) - 5 * Mathf.Sin(2 * t);

            Vector2 vector = new Vector2(x + transform.position.x, y + transform.position.y);
            Vector2 angle = (Vector2)transform.position - vector;
            float de = Mathf.Atan2(angle.y, angle.x) * Mathf.Rad2Deg + 90;
            float dis = Vector2.Distance(transform.position, vector);

            Shoot(transform.position, dis / 3, de, _skillDamage);
        }

        for (float t = 0; t < 2 * Mathf.PI; t += 0.05f * Mathf.PI)
        {
            float x = 5 * Mathf.Cos(2 * t) + 2 * Mathf.Cos(3 * t);
            float y = 2 * Mathf.Sin(3 * t) - 5 * Mathf.Sin(2 * t);

            Vector2 vector = new Vector2(x + transform.position.x, y + transform.position.y);
            Vector2 angle = (Vector2)transform.position - vector;
            float de = Mathf.Atan2(angle.y, angle.x) * Mathf.Rad2Deg + 90;
            float dis = Vector2.Distance(transform.position, vector);

            Bullet bullet = Shoot(transform.position, dis / 3, de, _skillDamage);
            StartCoroutine(ShrinkAndBoom(bullet, de, dis / 3, true));
        }
        yield return null;
    }
}
