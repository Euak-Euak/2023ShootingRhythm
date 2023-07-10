using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;

public class TestSkill : PlayerSkill
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SkillUseNormal();
        }
    }

    public IEnumerator AttackCircle()
    {
        for (int i = -45; i <= 45; i += 5)
        {
            Shoot(transform.position, 5f, i, _skillDamage);
            //Shoot(transfo rm, 5f, i + 180, skillDamage);
            yield return new WaitForSeconds(0.1f);
        }
    }

    IEnumerator Skill1()
    {
        Shoot(transform.position, 5f, 0, _skillDamage);
        yield return null;
    }

    IEnumerator Skill2()
    {
        Shoot(transform.position, 5f, -20, _skillDamage);
        Shoot(transform.position, 5f, 20, _skillDamage);
        Shoot(transform.position, 5f, 0, _skillDamage);
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
        Bullet bullet = Shoot(transform.position, 5f, angle, _skillDamage);

        float t = 0f;

        while (t < 1f)
        {
            t += Time.deltaTime;
            yield return null;
            if (!bullet.gameObject.activeSelf)
                yield break;
        }

        bullet.Init(bullet.transform.position, 5f, 180, _skillDamage);
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
                Shoot(trans, 5f, 0, _skillDamage);


                trans = new Vector3(transform.position.x - i, transform.position.y);
                Shoot(trans, 5f, 0, _skillDamage);

                yield return new WaitForSeconds(0.07f);
            }
            trans = new Vector3(transform.position.x, transform.position.y + 0.23f);
            Shoot(trans, 5f, 0, _skillDamage);
        }
        yield return null;
    }

    IEnumerator Skill5()
    {
        for (int i = 0; i <= 360; i += 5)
        {
            Shoot(transform.position, 5f, i, _skillDamage);
        }
        yield return null;
    }

    IEnumerator Skill6()
    {
        Bullet bullet = Shoot(transform.position, 5f, 0, _skillDamage);

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
            Shoot(bullet.transform.position, 5f, i, _skillDamage);
            bullet.gameObject.SetActive(false);
        }
        yield return null;
    }

    IEnumerator Skill7()
    {
        Bullet bullet = Shoot(transform.position, 0, 0, _skillDamage);

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
                    Shoot(bullet.transform.position, 5f, i, _skillDamage);
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

            Shoot(transform.position, dis /4, de, _skillDamage);
        }

        yield return null;
    }

    IEnumerator Skill9()
    {
        for (float t = 0; t < 2 * Mathf.PI; t += 0.05f * Mathf.PI)
        {
            float x = 5 * Mathf.Cos(2 * t) + 2 * Mathf.Cos(3 * t);
            float y = 2 * Mathf.Sin(3 * t) - 5 * Mathf.Sin(2 * t);

            Vector2 vector = new Vector2(x + transform.position.x, y + transform.position.y);
            Vector2 angle = (Vector2)transform.position - vector;
            float de = Mathf.Atan2(angle.y, angle.x) * Mathf.Rad2Deg + 90;
            float dis = Vector2.Distance(transform.position, vector);

            Shoot(transform.position, dis / 4, de, _skillDamage);
        }

        yield return null;
    }

    IEnumerator Skill10()
    {
        bool LR = true;
        for (float t = 0; t < 4; t += 0.4f)
        {
            Vector2 vector = new Vector2(transform.position.x, transform.position.y + t);

            float dis = Vector2.Distance(transform.position, vector);
            Bullet bullet = Shoot(transform.position, dis * 3, 0, _skillDamage);
            StartCoroutine(Skill10_s(bullet, LR));
            LR = !LR;
        }

        yield return null;
    }

    IEnumerator Skill10_s(Bullet bullet, bool LR)
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

    IEnumerator Skill11()
    {
        Bullet bullet = Shoot(transform.position, 5f, 0, _skillDamage);
        StartCoroutine(Skill11_s(bullet, 0));
        yield return null;
    }

    IEnumerator Skill11_s(Bullet bullet, int repeat)
    {
        if (repeat != 3)
        {
            float t = 0;
            while (t < 0.5f)
            {
                t += Time.deltaTime;
                yield return null;
                if (!bullet.gameObject.activeSelf)
                    yield break;
            }

            repeat++;

            for (int i = 0; i < 3; i++)
            {
                StartCoroutine(Skill11_s(Shoot(bullet.transform.position, 5f, i*120 + 20, _skillDamage), repeat));
            }
            bullet.gameObject.SetActive(false);
        }

        yield return null;
    }

    IEnumerator Skill12()
    {
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 360; j += 60)
            {
                Shoot(transform.position, 5f, j, _skillDamage);
            }
            yield return new WaitForSecondsRealtime(0.5f);
        }
        yield return null;
    }

    IEnumerator Skill13()
    {
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 360; j += 60)
            {
                Shoot(transform.position, 5f, j, _skillDamage);
            }
            yield return new WaitForSecondsRealtime(0.5f);
        }
        yield return null;
    }

    protected override void SkillUseNormal()
    {
        Debug.Log("Skillused");
        StartCoroutine(Skill8());
    }

    protected override void SkillUsePowerUp()
    {
        StartCoroutine(Skill13());
    }
}