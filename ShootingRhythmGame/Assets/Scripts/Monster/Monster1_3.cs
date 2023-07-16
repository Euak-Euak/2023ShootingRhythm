using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster1_3 : Monster
{
    private Animator anim;


    public void Start()
    {
        anim = GetComponent<Animator>();
    }


    public override void Attack()
    {
        StartCoroutine(Chkchkchkr());
    }


    IEnumerator Chkchkchkr()
    {
        yield return null;
        anim.SetTrigger("shoot");

        for (int i = 0; i < 3; i++)
        {
            for (int j = -135; j >= -225; j -= 45)
            {
                Shoot(transform.position, 5f, j, 1);
            }
            yield return new WaitForSeconds(0.1f);
        }
        for (int i = 0; i < 2; i++)
        {
            for (float j = -157.5f; j >= -202.5f; j -= 45)
            {
                Shoot(transform.position, 5f, j, 1);
            }
            yield return new WaitForSeconds(0.1f);
        }
    }
}
