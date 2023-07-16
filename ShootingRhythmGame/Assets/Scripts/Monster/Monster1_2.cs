using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster1_2 : Monster
{
    private Animator anim;


    public void Start()
    {
        anim = GetComponent<Animator>();
    }


    public override void Attack()
    {
        StartCoroutine(LeechSeedWhsskrp());
    }


    IEnumerator LeechSeedWhsskrp()
    {
        yield return null;
        anim.SetTrigger("shoot");

        for (int i = -135; i >= -225; i -= 45)
        {
            Shoot(transform.position - new Vector3(0f, 0.5f, 0f), 6f, i, 1);
        }

        for (int i = 0; i < 2; i++)
        {
            yield return new WaitForSeconds(0.1f);
            Shoot(transform.position, 6f, -180, 1);
        }
    }
}
