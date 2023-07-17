using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster3_1 : Monster
{
    public override void Attack()
    {
        StartCoroutine(ShootNut());
    }


    IEnumerator ShootNut()
    {
        yield return null;
        Bullet shoot = Shoot(transform.position, 1.5f, -180, 1);

        yield return new WaitForSeconds(1.3f);
        StartCoroutine(NutCrack(shoot));
    }


    IEnumerator NutCrack(Bullet shoot)
    {
        yield return null;
        for (int i = 90; i <= 270; i += 36)
        {
            Shoot(shoot.transform.position, 5f, i, 1);
        }
        shoot.ReturnObject();
    }
}
