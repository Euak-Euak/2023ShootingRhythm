using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Boss4 : Boss
{
    private void Start()
    {
        Invoke("Attack", 0.1f);
    }

    public override void Attack()
    {
        StartCoroutine(Phase2_Pattern4());
        Invoke("Attack", 6f);
    }

    IEnumerator Phase1_Pattern1()
    {
        Vector2 OriginalVec = transform.position;
        Vector2 RandVec = new Vector2(transform.position.x + Random.Range(-3.0f, 3.0f), transform.position.y + (Random.Range(-1f, 3f)));

        transform.DOMove(RandVec, 1f).OnComplete(() => transform.DOMove(RandVec, 0.3f).OnComplete(() => transform.DOMove(OriginalVec, 5f)));
        for (int i = 0; i < 2; i++)
        {
            for (int j = 0; j < 115; j++)
            {
                Bullet bullet = Shoot(transform.position, Random.Range(0.5f, 4.5f), Random.Range(0, 360), 1);
                StartCoroutine(Phase1_Pattern1_S(bullet));
            }
            yield return new WaitForSecondsRealtime(0.01f);
        }
        yield return new WaitForSecondsRealtime(1.8f);

        for (int i = 0; i < 15; i++)
        {
            for (float j = 70; j < 250; j += 22.5f)
            {
                Shoot(transform.position, Random.Range(4f, 6f), j, 1);
            }
            yield return new WaitForSecondsRealtime(0.04f);
        }
    }
    IEnumerator Phase1_Pattern1_S(Bullet bullet)
    {
        yield return new WaitForSecondsRealtime(2f);
        if (!bullet.gameObject.activeSelf)
            yield break;

        bullet.Init(bullet.transform.position, 0, 0, 1);
        yield return new WaitForSecondsRealtime(3.7f);
        if (!bullet.gameObject.activeSelf)
            yield break;

        bullet.Init(bullet.transform.position, 2f, Random.Range(70, 290), 1);
    }

    IEnumerator Phase1_Pattern2()
    {
        for (float j = 0; j < 4; j++)
        {
            for (int i = 0; i < 16; i++)
            {
                Bullet bullet = Shoot(transform.position, 0.5f + (i * 0.15f), 135 + (i * 10f), 1);
                StartCoroutine(Phase1_Pattern2_S(bullet));
            }
            yield return new WaitForSecondsRealtime(1f);

            for (int i = 0; i < 360; i+=30)
            {
                Bullet bullet = Shoot(transform.position, 4f, i, 1);
            }

            for (int i = 0; i < 16; i++)
            {
                Bullet bullet = Shoot(transform.position, 0.5f + (i * 0.15f), 225 - (i * 10f), 1);
                StartCoroutine(Phase1_Pattern2_S(bullet));
            }
            yield return new WaitForSecondsRealtime(1f);

            for (int i = 0; i < 360; i += 30)
            {
                Bullet bullet = Shoot(transform.position, 4f, i, 1);
            }
        }
        yield return null;
    }
    IEnumerator Phase1_Pattern2_S(Bullet bullet)
    {
        yield return new WaitForSecondsRealtime(0.8f);
        if (!bullet.gameObject.activeSelf)
            yield break;
        bullet.Init(bullet.transform.position, 0, 180, 1);
        float de = -1 * Quaternion.FromToRotation(Vector3.up, _playerTransform.position - bullet.transform.position).eulerAngles.z;

        yield return new WaitForSecondsRealtime(0.5f);
        if (!bullet.gameObject.activeSelf)
            yield break;

        Shoot(bullet.transform.position, 6, de, 1);
        bullet.Init(bullet.transform.position, 5, de, 1);
    }

    IEnumerator Phase1_Pattern3_Right()
    {
        Vector2 under = new Vector2(transform.position.x + 0.7f, transform.position.y);
        Laser laser = Beam(under, 90, 1, 0.4f, 5f);

        for (int i = 90; i < 145; i++)
        {
            laser.Init(under, i, 1);
            yield return new WaitForSecondsRealtime(0.02f);
        }
        for (int i = 145; i >= -180; i--)
        {
            laser.Init(under, i, 1);
            yield return new WaitForSecondsRealtime(0.001f);
        }
        yield return new WaitForSecondsRealtime(0.5f);
        laser.gameObject.SetActive(false);
        yield return null;
    }
    IEnumerator Phase1_Pattern3_Left()
    {
        Vector2 under = new Vector2(transform.position.x - 0.7f, transform.position.y);
        Laser laser = Beam(under, -90, 1, 0.4f, 5f);

        for (int i = -90; i > -145; i--)
        {
            laser.Init(under, i, 1);
            yield return new WaitForSecondsRealtime(0.02f);
        }
        for (int i = -145; i <= 180; i++)
        {
            laser.Init(under, i, 1);
            yield return new WaitForSecondsRealtime(0.001f);
        }
        yield return new WaitForSecondsRealtime(0.5f);
        laser.gameObject.SetActive(false);
        yield return null;
    }

    IEnumerator Phase2_Pattern1()
    {
        for (int k = 0; k < 8; k++)
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 45; j += 9)
                {
                    if (j < 30)
                    {
                        Shoot(transform.position, 1.5f, 45 * i + j, 1);
                    }
                }
            }
            yield return new WaitForSecondsRealtime(0.04f);
        }
    }
    IEnumerator Phase2_Pattern2()
    {
        for (int k = 0; k < 6; k++)
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 45; j += 9)
                {
                        Bullet bullet = Shoot(transform.position, 0.5f, 45 * i + j + (k * 8), 1);
                        StartCoroutine(Phase2_Pattern2_S(bullet, j, 45 * i + j + (k * 8), k));
                }
            }
            yield return new WaitForSecondsRealtime(0.2f);
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 45; j += 9)
                {
                    Bullet bullet = Shoot(transform.position, 0.5f, 45 * i + j + (k * 8), 1);
                    StartCoroutine(Phase2_Pattern2_S(bullet, 45 - j, 45 * i + j + (k * 8), k + 1));
                }
            }
            k++;
            yield return new WaitForSecondsRealtime(0.2f);
        }
    }
    IEnumerator Phase2_Pattern2_S(Bullet bullet, int speed, float angle, int waitTime)
    {
        yield return new WaitForSecondsRealtime(1f + (waitTime * 0.4f));
        bullet.Init(bullet.transform.position, 2f + (speed / 9 * 0.2f), angle, 1);
    }

    IEnumerator Phase2_Pattern3()
    {
        for (float j = 0; j < 4; j++)
        {
            for (int i = 0; i < 16; i++)
            {
                Shoot(transform.position, 4 + (i * 0.6f), 135 + (i * 10f), 1);
            }
            yield return new WaitForSecondsRealtime(0.5f);
            for (int k = 0; k < 2; k++)
            {
                for (int i = 0; i < 360; i+=20)
                {
                    Shoot(transform.position, 3f, i, 1);
                }
                yield return new WaitForSecondsRealtime(0.2f);
            }
            for (int i = 0; i < 16; i++)
            {
                Shoot(transform.position, 4 + (i * 0.6f), 225 - (i * 10f), 1);
            }
            yield return new WaitForSecondsRealtime(0.5f);
        }
        yield return null;
    }

    IEnumerator Phase2_Pattern4()
    {
        Vector2 OriginalPos = transform.position;
        Vector2 randVec = new Vector2(Random.Range(_leftEdge.position.x, _rightEdge.position.x), Random.Range(_upEdge.position.y, _downEdge.position.y));

        StartCoroutine(Phase2_Pattern3());
        transform.DOMove(randVec, 2f).OnComplete(() => transform.DOMove(OriginalPos, 0.5f).OnComplete(() => transform.DOMove(OriginalPos, 0.5f).OnComplete(() =>
        {
            Vector2 randVec = new Vector2(Random.Range(_leftEdge.position.x, _rightEdge.position.x), Random.Range(_upEdge.position.y, _downEdge.position.y));
            transform.DOMove(randVec, 2f).OnComplete(() => transform.DOMove(OriginalPos, 0.5f)); })));
        yield return null;
    }

    public override void Phase1()
    {
        throw new System.NotImplementedException();
    }

    public override void Phase2()
    {
        throw new System.NotImplementedException();
    }
}
