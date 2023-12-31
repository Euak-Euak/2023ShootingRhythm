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

    IEnumerator Skill5()
    {
        for (int i = 0; i <= 360; i += 5)
        {
            Shoot(transform.position, 5f, i, _skillDamage);
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
        /*
         Bullet bullet = Shoot(transform.position, 2.5f, 0, _skillDamage);

        float t = 0f;

        while (t < 0.5f)
        {
            t += Time.deltaTime;
            yield return null;
            if (!bullet.gameObject.activeSelf)
                yield break;
        }

        bullet.gameObject.SetActive(false);

         */
    }

    protected override void SkillUsePowerUp()
    {
        StartCoroutine(Skill13());
    }
}