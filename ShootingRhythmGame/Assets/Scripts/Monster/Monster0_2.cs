using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster0_2 : Monster
{
    private Animator anim;


    private void Start()
    {
        anim = GetComponent<Animator>();
    }


    public override void Attack()
    {
        StartCoroutine(ReturnNutt());
    }


    IEnumerator ReturnNutt()
    {
        yield return null;
        anim.SetTrigger("shoot");

        yield return new WaitForSeconds(1f);
        Bullet shoot = Shoot(transform.position + new Vector3(0f, -0.8f, 0f), 1f, -180, 1);
        shoot.transform.localScale = new Vector3 (1f, 1f, 1f);
    }
}
