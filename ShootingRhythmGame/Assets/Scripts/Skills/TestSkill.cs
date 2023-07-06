using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSkill : PlayerSkill
{
    int skillDamage;

    private void Start()
    {
        DataManager.Instance.OpenDB();
        skillDamage = DataManager.Instance.SkillValue(1);
        DataManager.Instance.CloseDB();
    }

    public override void SkillUse()
    {
        StartCoroutine(Skill8());
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SkillUse();
        }
    }

    IEnumerator AttackCircle()
    {
        for (int i = -45; i <= 45; i += 5)
        {
            Shoot(transform.position, 5f, i, skillDamage);
            //Shoot(transfo rm, 5f, i + 180, skillDamage);
            yield return new WaitForSeconds(0.1f);
        }
    }

    IEnumerator Skill1()
    {
        Shoot(transform.position, 5f, 0, skillDamage);
        yield return null;
    }

    IEnumerator Skill2()
    {
        Shoot(transform.position, 5f, -20, skillDamage);
        Shoot(transform.position, 5f, 20, skillDamage);
        Shoot(transform.position, 5f, 0, skillDamage);
        yield return new WaitForSeconds(0.1f);
    }

    IEnumerator Skill3()
    {
        for (int i = -20; i <= 20; i += 10)
        {
            StartCoroutine(Skill3_s(i));
        }
        yield return null;
    }

    IEnumerator Skill3_s(int angle)
    {
        Bullet bullet = Shoot(transform.position, 5f, angle, skillDamage);

        float t = 0f;

        while (t < 1f)
        {
            t += Time.deltaTime;
            yield return null;
            if (!bullet.gameObject.activeSelf)
                yield break;
        }

        bullet.Init(bullet.transform, 5f, 180, skillDamage);
        yield return null;
    }

    IEnumerator Skill4()
    {
        for (int j = 0; j < 5; j++)
        {
            Vector3 trans;


            for (float i = -0.4f; i <= 0.4f; i += 0.2f)
            {
                trans = new Vector3(transform.position.x + i, transform.position.y);
                Shoot(trans, 5f, 0, skillDamage);


                trans = new Vector3(transform.position.x - i, transform.position.y);
                Shoot(trans, 5f, 0, skillDamage);

                yield return new WaitForSeconds(0.07f);
            }
            trans = new Vector3(transform.position.x, transform.position.y + 0.23f);
            Shoot(trans, 5f, 0, skillDamage);
        }
        yield return null;
    }

    IEnumerator Skill5()
    {
        for (int i = 0; i <= 360; i += 5)
        {
            Shoot(transform.position, 5f, i, skillDamage);
        }
        yield return null;
    }

    IEnumerator Skill6()
    {
        Bullet bullet = Shoot(transform.position, 5f, 0, skillDamage);

        float t = 0f;

        while (t < 1f)
        {
            t += Time.deltaTime;
            yield return null;
            if (!bullet.gameObject.activeSelf)
                yield break;
        }

        for (int i = 0; i <= 360; i += 5)
        {
            Shoot(bullet.transform.position, 5f, i, skillDamage);
            bullet.gameObject.SetActive(false);
        }
        yield return null;
    }

    IEnumerator Skill7()
    {
        Bullet bullet = Shoot(transform.position, 0, 0, skillDamage);

        float t = 0f;

        while (t < 0.5f)
        {
            t += Time.deltaTime;
            yield return null;
            if (!bullet.gameObject.activeSelf)
                yield break;
        }

        t = 0f;
        for (int j = 0; j < 3;)
        {
            if (!bullet.gameObject.activeSelf)
                yield break;

            t += Time.deltaTime;
            if (t >= 0.6f)
            {
                for (int i = 0; i <= 360; i += 5)
                {
                    Shoot(bullet.transform.position, 5f, i, skillDamage);
                }
                t = 0;
                j++;
            }
            yield return null;
        }

        bullet.gameObject.SetActive(false);
        yield return null;
    }

    IEnumerator Skill8()
    {
        for (float t = 0; t < 2 * Mathf.PI; t += 0.05f * Mathf.PI)
        {
            float x = 16 * Mathf.Sin(t) * Mathf.Sin(t) * Mathf.Sin(t);
            float y = 13 * Mathf.Cos(t) - 5 * Mathf.Cos(2 * t) - 2 * Mathf.Cos(3 * t) - Mathf.Cos(4 * t);

            Vector2 vector = new Vector2(x + transform.position.x , y + transform.position.y);
            Vector2 angle = (Vector2)transform.position - vector; 
            float de = Mathf.Atan2(angle.y, angle.x) * Mathf.Rad2Deg + 90;
            float dis = Vector2.Distance(transform.position, vector);

            Shoot(transform.position, dis /4, de, skillDamage);
        }

        yield return null;
    }
}