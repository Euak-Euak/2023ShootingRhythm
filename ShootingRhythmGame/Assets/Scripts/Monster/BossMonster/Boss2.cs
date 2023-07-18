using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Boss2 : Boss
{
    [SerializeField] private Boss2Heart _bossHeart1;
    [SerializeField] private Boss2Heart _bossHeart2;

    private void Start()
    {
        Invoke("Attack", 0.1f);
    }

    public override void Phase2()
    {
        switch (Random.Range(0, 3))
        {
            case 0:
                StartCoroutine(Phase2_Pattern1());
                break;
            case 1:
                StartCoroutine(Phase2_Pattern2());
                break;
            case 2:
                StartCoroutine(Phase2_Pattern3());
                break;
            default:
                break;
        }
    }
    public override void Phase1()
    {
        int a = Random.Range(0, 5);
        switch (a)
        {
            case 0:
                StartCoroutine(Phase1_Pattern1());
                break;
            case 1:
                StartCoroutine(Phase1_Pattern2_Right());
                break;
            case 2:
                StartCoroutine(Phase1_Pattern3());
                break;
            case 3:
                StartCoroutine(Phase1_Pattern4());
                break;
            case 4:
                StartCoroutine(Phase1_Pattern2_Left());
                break;
            default:
                break;
        }
    }

    IEnumerator Phase1_Pattern1()
    {
        for (int k = 0; k < 3; k++)
        {
            for (int i = 0; i < 45; i += 10)
            {
                for (int j = 0; j < 360; j += 45)
                {
                    Shoot(transform.position, 5f, j + i, 1);
                    Shoot(transform.position, 5f, j + i + 5, 1);
                }
                yield return new WaitForSecondsRealtime(0.1f);
            }

            for (int i = 45; i > 0; i -= 10)
            {
                for (int j = 0; j < 360; j += 45)
                {
                    Shoot(transform.position, 5f, j + i, 1);
                    Shoot(transform.position, 5f, j + i - 5, 1);
                }
                yield return new WaitForSecondsRealtime(0.1f);
            }
        }
        yield return null;
    }

    IEnumerator Phase1_Pattern2_Right()
    {
        Vector2 OriginalPos = transform.position;
        Laser laser =  Beam(transform.position, 180, 1, 0.3f, 3f);
        laser.SetBulletData((GameObject)Resources.Load("BulletData/lazer"));
        float f = 0;
        while (f <= 3f)
        {
            Vector2 movement = new Vector2(_rightEdge.position.x - transform.position.x, 0) * Time.deltaTime;
            transform.position = new Vector2(transform.position.x + movement.x, transform.position.y);
            Vector2 laserMovement = new Vector2(laser.transform.position.x + movement.x, laser.transform.position.y);
            laser.Init(laserMovement, 180, 1);
            f += Time.deltaTime;
            yield return null;
        }

        laser.gameObject.SetActive(false);
        f = 0;
        while (f <= 1f)
        {
            Vector2 movement = new Vector2(OriginalPos.x - transform.position.x, 0) * Time.deltaTime * 3;
            transform.position = new Vector2(transform.position.x + movement.x, transform.position.y);
            f += Time.deltaTime;
            yield return null;
        }
        yield return null;
    }

    IEnumerator Phase1_Pattern2_Left()
    {
        Vector2 OriginalPos = transform.position;
        Laser laser = Beam(transform.position, 180, 1, 0.3f, 4f);
        laser.SetBulletData((GameObject)Resources.Load("BulletData/lazer"));

        float f = 0;
        while (f <= 3f) 
        { 
            Vector2 movement = new Vector2(_leftEdge.position.x - transform.position.x, 0) * Time.deltaTime;
            transform.position = new Vector2(transform.position.x + movement.x, transform.position.y);
            Vector2 laserMovement = new Vector2(laser.transform.position.x + movement.x, laser.transform.position.y);
            laser.Init(laserMovement, 180, 1);
            f += Time.deltaTime;
            yield return null;
        }
        laser.gameObject.SetActive(false);
        f = 0;
        while (f <= 1f)
        {
            Vector2 movement = new Vector2(OriginalPos.x - transform.position.x, 0) * Time.deltaTime * 3;
            transform.position = new Vector2(transform.position.x + movement.x, transform.position.y);
            f += Time.deltaTime;
            yield return null;
        }
        yield return null;
    }

    IEnumerator Phase1_Pattern3()
    {
        Bullet bullet = Shoot(transform.position, 5f, 180, 1);
        StartCoroutine(Phase1_Pattern3_S(bullet, 0.5f, 1));
        yield return null;
    }
    IEnumerator Phase1_Pattern3_S(Bullet bullet, float time, int repeat)
    {
        if (repeat == 3)
            yield break;

        float f = 0;
        while (f <= time)
        {
            f += Time.deltaTime;
            yield return null;
            if (!bullet.gameObject.activeSelf)
                yield break;
        }

        for (int i = 0; i < 360; i += 45)
        {
            Bullet bullet2 = Shoot(bullet.transform.position, 2f, i, 1);
            StartCoroutine(Phase1_Pattern3_S(bullet2, 1.5f, repeat + 1));
        }
        bullet.gameObject.SetActive(false);
        yield return null;
    }

    IEnumerator Phase1_Pattern4()
    {
        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 360; j += 45)
            {
                Shoot(transform.position, 8f, j + (i * 2), 1);
            }
            for (int j = 0; j < 360; j += 45)
            {
                Shoot(transform.position, 3f, j - 5, 1);
            }
            yield return new WaitForSecondsRealtime(0.1f);
        }
        yield return null;
    }

    IEnumerator Phase2_Pattern1()
    {
        if (_bossHeart1.isActive)
            yield break;
        StartCoroutine(_bossHeart1.Appear());
        StartCoroutine(_bossHeart2.Appear());
        yield return new WaitForSecondsRealtime(17f);
        StartCoroutine(_bossHeart1.Disappear());
        StartCoroutine(_bossHeart2.Disappear());
        yield return null;
    }

    IEnumerator Phase2_Pattern2()
    {
        for (int i = 0; i < 360; i += 45)
        {
            Debug.Log("aa");
            Laser laser = Beam(transform.position, i, 1, 0.8f, 5f);
            StartCoroutine(Phase2_Pattern2_S(laser, i));
        }
        yield return null;
    }

    IEnumerator Phase2_Pattern2_S(Laser laser, float angle)
    {
        yield return new WaitForSecondsRealtime(0.1f);
        for (int i = 0; i < 50; i += 1)
        {
            laser.Init(laser.transform.position, angle + i, 1);
            yield return new WaitForSecondsRealtime(0.025f);
        }
        yield return new WaitForSecondsRealtime(0.3f);
        for (int i = 0; i < 70; i += 1)
        {
            laser.Init(laser.transform.position, angle - i, 1);
            yield return new WaitForSecondsRealtime(0.025f);
        }
        yield return new WaitForSecondsRealtime(0.3f);
        laser.gameObject.SetActive(false);
        yield return null;
    }

    IEnumerator Phase2_Pattern3()
    {
        float de = -1 * Quaternion.FromToRotation(Vector3.up, _playerTransform.position - transform.position).eulerAngles.z;
        for (int i = 2; i < 7; i++)
        {
            if (i%2 == 1)
            {
                Shoot(transform.position, 6.5f, de, 1);
                for (int j = (i - 1)/2; j > 0; j--)
                {
                    Shoot(transform.position, 6.5f, de + (5f * j), 1);
                    Shoot(transform.position, 6.5f, de - (5f * j), 1);
                }
            }
            else
            {
                Shoot(transform.position, 6.5f, de + 2.5f, 1);
                Shoot(transform.position, 6.5f, de - 2.5f, 1);
                for (int j = (i - 2)/2; j > 0; j--)
                {
                    Shoot(transform.position, 6.5f, de + (5f * j) + 2.5f, 1);
                    Shoot(transform.position, 6.5f, de - (5f * j) - 2.5f, 1);
                }
            }
            
            yield return new WaitForSecondsRealtime(0.08f);
        }
        yield return null;
    }

}