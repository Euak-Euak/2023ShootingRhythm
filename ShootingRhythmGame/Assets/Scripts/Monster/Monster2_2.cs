using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster2_2 : Monster
{
    private int dir = 1;


    public void Start()
    {
        StartCoroutine(SteampunkInvaders());
    }


    public override void Attack()
    {
        StartCoroutine(Qyd());
    }


    IEnumerator SteampunkInvaders()
    {
        yield return null;
        while (true)
        {
            for (int i = 0; i < 5; i++)
            {
                transform.position += new Vector3(dir, 0f, 0f);
                yield return new WaitForSeconds(1.2f);
            }
            transform.position += new Vector3(0f, -0.8f, 0f);
            dir = -dir;
            yield return new WaitForSeconds(1.4f);
        }
    }


    IEnumerator Qyd()
    {
        while (true)
        {
            Shoot(transform.position, 3f, -180, 1);
            yield return new WaitForSeconds(1.4f);
        }
    }
}
