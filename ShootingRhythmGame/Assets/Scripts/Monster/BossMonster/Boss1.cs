using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1 : Boss
{
    private void Start()
    {
        Invoke("Attack", 0.1f);
    }

    public override void Phase2()
    {

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
    }
    public override void Phase1()
    {
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
    }

    IEnumerator Phase1_Pattern1()
    {
        float de = -1 * Quaternion.FromToRotation(Vector3.up, _playerTransform.position - transform.position).eulerAngles.z;
        for (int j = 0; j < 15; j++)
        {
            for (int i = 1; i < 3; i++)
            {
                Shoot(transform.position, 7f, de + (i * 20), 1);
                Shoot(transform.position, 7f, de + (i * -20), 1);
            }
            if (j == 1)
            {
                StartCoroutine(Phase1_Pattern2());
            }
            yield return new WaitForSecondsRealtime(0.1f);
        }

        yield break;
    }
    IEnumerator Phase1_Pattern2()
    {
        yield return null;
        
        for (int j = 0; j < 5; j++)
        {
            for (int i = 0; i < 360; i += 30)
            {
                Shoot(transform.position, 3f, i + (j * 15), 1);
            }
            yield return new WaitForSecondsRealtime(0.2f);
        }
        yield break;
    }
    IEnumerator Phase1_Pattern3()
    {
        float de = -1 * Quaternion.FromToRotation(Vector3.up, _playerTransform.position - transform.position).eulerAngles.z;

        for (int j = 0; j < 4; j++)
        {
            for (float i = de; i < de + 360; i += 30)
            {
                Shoot(transform.position, 5f, i + (j * 5), 1);
                yield return new WaitForSecondsRealtime(0.01f);
            }

            for (int i = 0; i < 360; i += 30)
            {
                Shoot(transform.position, 3f, i, 1);
            }
        }
        yield return null;
    }
    IEnumerator Phase1_Pattern4()
    {
        float de = -1 * Quaternion.FromToRotation(Vector3.up, _playerTransform.position - transform.position).eulerAngles.z;
        for(int j = 0; j < 6; j++)
        {
            StartCoroutine(Phase1_Pattern4_s(Random.Range(4f, 7f), Random.Range(-8f, 8f) + de));
        }
        yield return null;
    }
    IEnumerator Phase1_Pattern4_s(float speed, float angle)
    {
        for (int i = 0; i < Random.Range(5, 8); i++)
        {
            Shoot(transform.position, speed, angle, 1);
            yield return new WaitForSecondsRealtime(0.05f);
        }
    }

    IEnumerator Phase2_Pattern1()
    {
        for (int j = 0; j < 10; j++)
        {
            for (int i = 0; i < 10; i++)
            {
                Shoot(transform.position, Random.Range(3f, 8f), Random.Range(90, 271), 1);
            }
            yield return new WaitForSecondsRealtime(0.2f);
        }
        yield return null;
    }

    IEnumerator Phase2_Pattern2()
    {
        float de = -1 * Quaternion.FromToRotation(Vector3.up, _playerTransform.position - transform.position).eulerAngles.z;
        for (int i = 0; i < 10; i++)
        {
            for (int j = -15; j < 15; j+= 2)
            {
                Shoot(transform.position, Random.Range(2f, 6f), de + j ,1);
            }
            yield return new WaitForSecondsRealtime(0.1f);
        }
        yield return null;
    }

    IEnumerator Phase2_Pattern3()
    {
        for (float j = 0; j <= 22.5; j += 4.5f)
        {
            for (int i = 0; i < 360; i += 45)
            {
                Shoot(transform.position, 4f, i + j, 1);
                Shoot(transform.position, 4f, i - j, 1);
            }
            yield return new WaitForSecondsRealtime(0.15f);
        }
        yield return null;
    }

    IEnumerator Phase2_Pattern4()
    {
        for (float j = 0; j < 4; j++)
        {
            for (int i = 0; i < 16; i++)
            {
                Shoot(transform.position, 4 + (i * 0.6f), 135 + (i * 10f), 1);
            }
            yield return new WaitForSecondsRealtime(0.5f);

            for (int i = 0; i < 16; i++)
            {
                Shoot(transform.position, 4 + (i * 0.6f), 225 - (i * 10f), 1);
            }
            yield return new WaitForSecondsRealtime(0.5f);
        }
        yield return null;
    }

    IEnumerator Phase2_Pattern5()
    {
        for(float j = 0;j < 4; j++)
        {
            for (int i = 0; i < 360; i += 20)
            {
                Bullet bullet = Shoot(transform.position, 3f, i, 1);
                StartCoroutine(Phase2_Pattern5_S(bullet));
            }
            yield return new WaitForSecondsRealtime(0.5f);
            for (int i = 0; i < 360; i += 30)
            {
                Bullet bullet = Shoot(transform.position, 4f, i, 1);
            }
            yield return new WaitForSecondsRealtime(0.2f);
        }
        yield return null;
    }

    IEnumerator Phase2_Pattern5_S(Bullet bullet)
    {
        float t = 0;
        while (t < 0.4f)
        {
            t += Time.deltaTime;
            yield return null;
            if (!bullet.gameObject.activeSelf)
                yield break;
        }
        bullet.Init(bullet.transform.position, 0, 0, 1);

        t = 0;
        while (t < 0.5f)
        {
            t += Time.deltaTime;
            yield return null;
            if (!bullet.gameObject.activeSelf)
                yield break;
        }
        float de = -1 * Quaternion.FromToRotation(Vector3.up, _playerTransform.position - bullet.transform.position).eulerAngles.z;
        bullet.Init(bullet.transform.position, 6f, de, 1);

        yield return null;
    }
}
