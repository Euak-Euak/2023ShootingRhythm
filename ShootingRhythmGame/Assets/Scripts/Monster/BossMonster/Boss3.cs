using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class Boss3 : Boss
{
    private void Start()
    {
        Invoke("Attack", 0.1f);
    }

    public override void Attack()
    {
        /*
        switch (Random.Range(0, 5))
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
            case 3:
                StartCoroutine(Phase2_Pattern4());
                break;
            case 4:
                StartCoroutine(Phase2_Pattern5());
                break;
            default:
                break;
        }
        */
        StartCoroutine(Phase2_Pattern3());
        Invoke("Attack", 5f);
        /*
        switch (Random.Range(0, 4))
        {
            case 0:
                StartCoroutine(Phase1_Pattern1());
                break;
            case 1:
                StartCoroutine(Phase1_Pattern2());
                break;
            case 2:
                StartCoroutine(Phase1_Pattern3());
                break;
            case 3:
                StartCoroutine(Phase1_Pattern4());
                break;
            default:
                break;
        }
        */
    }

    IEnumerator Phase1_Pattern1()
    {
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 18; j++)
            {
                Shoot(transform.position, Random.Range(2f, 4f), Random.Range(0, 360), 1);
            }
            yield return new WaitForSecondsRealtime(0.5f);
        }
        yield return null;
    }

    IEnumerator Phase1_Pattern2()
    {
        for (int k = 0; k < 10; k++)
        {
            for (int i = -1; i <= 1; i += 2)
            {
                for (int j = 0; j < 2; j++)
                {
                    Vector3 newVec = new Vector3(transform.position.x + i + (j * i), transform.position.y + j);
                    StartCoroutine(Phase1_Pattern2_S(newVec));
                }
            }
            yield return new WaitForSecondsRealtime(0.05f);
        }

        yield return null;
    }
    IEnumerator Phase1_Pattern2_S(Vector3 transform)
    {
        float de = -1 * Quaternion.FromToRotation(Vector3.up, _playerTransform.position - transform).eulerAngles.z;
        Shoot(transform, 7f, de, 1);
        yield return null;
    }

    IEnumerator Phase1_Pattern3()
    {
        float de = -1 * Quaternion.FromToRotation(Vector3.up, _playerTransform.position - transform.position).eulerAngles.z;

        Bullet bullet = Shoot(transform.position, 1f, de, 1);
        StartCoroutine(Phase1_Pattern3_S(bullet));
        while (bullet.gameObject.activeSelf)
        {
            yield return new WaitForSecondsRealtime(0.5f);
            for (float i = de; i < de + 360; i+=45)
            {
                Shoot(bullet.transform.position, 3.5f, i, 1);
            }
            for (float i = de + 25; i < de + 385; i += 90)
            {
                Shoot(bullet.transform.position, 2f, i, 1);
            }
        }
        yield return null;
    }
    IEnumerator Phase1_Pattern3_S(Bullet bullet)
    {
        yield return new WaitForSecondsRealtime(4f);
        bullet.gameObject.SetActive(false);
    }

    IEnumerator Phase1_Pattern4_Right()
    {
        Vector2 RightVec = new Vector2(transform.position.x + 0.8f, transform.position.y);
        Laser laser = Beam(RightVec, 0, 1, 0.4f, 5f);
        yield return new WaitForSecondsRealtime(0.9f);

        for (int i = 0; i < 200; i++)
        {
            laser.Init(RightVec, i, 1);
            yield return new WaitForSecondsRealtime(0.005f);
        }
        yield return new WaitForSecondsRealtime(0.3f);
        laser.gameObject.SetActive(false);

        yield return null;
    }
    IEnumerator Phase1_Pattern4_Left()
    {
        Vector2 LeftVec = new Vector2(transform.position.x - 0.8f, transform.position.y);
        Laser laser = Beam(LeftVec, 0, 1, 0.4f, 5f);
        yield return new WaitForSecondsRealtime(0.9f);

        for (int i = 0; i > -200; i--)
        {
            laser.Init(LeftVec, i, 1);
            yield return new WaitForSecondsRealtime(0.005f);
        }
        yield return new WaitForSecondsRealtime(0.3f);
        laser.gameObject.SetActive(false);

        yield return null;
    }
    IEnumerator Phase1_Pattern4_LeftRight()
    {
        StartCoroutine(Phase1_Pattern4_Left());
        yield return new WaitForSecondsRealtime(2f);
        StartCoroutine(Phase1_Pattern4_Right());

        yield return null;
    }
    IEnumerator Phase1_Pattern4_RightLeft()
    {
        StartCoroutine(Phase1_Pattern4_Right());
        yield return new WaitForSecondsRealtime(2f);
        StartCoroutine(Phase1_Pattern4_Left());

        yield return null;
    }
    IEnumerator Phase1_Pattern4_Both()
    {
        Vector2 RightVec = new Vector2(transform.position.x + 0.8f, transform.position.y);
        Vector2 LeftVec = new Vector2(transform.position.x - 0.8f, transform.position.y);
        Laser laser = Beam(RightVec, 0, 1, 0.4f, 5f);
        Laser laser2 = Beam(LeftVec, 0, 1, 0.4f, 5f);
        yield return new WaitForSecondsRealtime(0.9f);

        for (int i = 0; i < 175; i++)
        {
            laser.Init(RightVec, i, 1);
            laser2.Init(LeftVec, i * -1, 1);
            yield return new WaitForSecondsRealtime(0.005f);
        }
        yield return new WaitForSecondsRealtime(0.3f);
        laser.gameObject.SetActive(false);
        laser2.gameObject.SetActive(false);
        yield return null;
    }

    IEnumerator Phase2_Pattern1()
    {
        for (int j = 0; j < 5; j++)
        {
            for (int i = 0; i < 360; i += 15)
            {
                float speed = j * 0.35f;
                Bullet bullet = Shoot(transform.position, 1f + speed, i, 1);
                StartCoroutine(Phase2_Pattern1_S(bullet, i));
            }
        }
        yield return new WaitForSecondsRealtime(1.4f);
        for (int j = 0; j < 5; j++)
        {
            for (int i = 0; i < 360; i += 15)
            {
                float speed = j * 0.35f;
                Bullet bullet = Shoot(transform.position, 1f + speed, i, 1);
                StartCoroutine(Phase2_Pattern1_2S(bullet, i));
            }
        }

        yield return null;
    }
    IEnumerator Phase2_Pattern1_S(Bullet bullet, float angle)
    {
        yield return new WaitForSecondsRealtime(1f);
        bullet.Init(bullet.transform.position, 0.05f, angle, 1);

        yield return new WaitForSecondsRealtime(0.4f);
        bullet.Init(bullet.transform.position, 5f, angle + 150, 1);

        yield return null;
    }
    IEnumerator Phase2_Pattern1_2S(Bullet bullet, float angle)
    {
        yield return new WaitForSecondsRealtime(1f);
        bullet.Init(bullet.transform.position, 0.05f, angle, 1);

        yield return new WaitForSecondsRealtime(0.4f);
        bullet.Init(bullet.transform.position, 5f, angle + -150, 1);

        yield return null;
    }

    IEnumerator Phase2_Pattern2()
    {
        for (int i = -1; i <= 1; i += 2)
        {
            for (int j = 0; j < 2; j++)
            {
                Vector3 newVec = new Vector3(transform.position.x + i + (j * i), transform.position.y + j);
                StartCoroutine(Phase2_Pattern2_S(newVec));
            }
            yield return new WaitForSecondsRealtime(0.05f);
        }
        yield return null;
    }
    IEnumerator Phase2_Pattern2_S(Vector3 transform)
    {
        int randAngle = 360/Random.Range(3, 9);
        int randShoot = Random.Range(3, 9);
        float randSpeed = Random.Range(3.5f, 3.8f);
        for (int k = 0; k < 5; k++)
        {
            for (int i = 0; i < 360; i += randAngle)
            {
                for (int j = 0; j < randShoot; j++)
                {
                    Shoot(transform, randSpeed, i + (j * 2), 1);
                }
            }
            yield return new WaitForSecondsRealtime(0.2f);
        }

        yield return null;
    }

    IEnumerator Phase2_Pattern3()
    {
        Vector2 OriginalPos = transform.position;
        Vector2 randVec = new Vector2(Random.Range(_leftEdge.position.x, _rightEdge.position.x), Random.Range(_upEdge.position.y, _downEdge.position.y));
        
        StartCoroutine(Phase1_Pattern1());
        transform.DOMove(randVec, 2f).OnComplete(()=> transform.DOMove(OriginalPos, 0.5f));
        yield return null;
    }
}
