using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster3_1 : Monster
{
    private Animator anim;


    public void Start()
    {
        anim = GetComponent<Animator>();
    }


    public override void Attack()
    {
        StartCoroutine(ShootNut());
    }


    IEnumerator ShootNut()
    {
        yield return null;
        Bullet shoot = Shoot(transform.position, 1f, -180, 1);

        yield return new WaitForSeconds(1.3f);
        anim.SetTrigger("shoot");

        yield return new WaitForSeconds(0.1f);
        StartCoroutine(NutCrack(shoot));
    }


    IEnumerator NutCrack(Bullet shoot)
    {
        yield return null;
        for (int i = 90; i <= 270; i += 20)
        {
            Shoot(shoot.transform.position, 6f, i, 1);
        }
        shoot.ReturnObject();
    }
}
