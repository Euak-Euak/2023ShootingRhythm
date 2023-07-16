using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster1_1 : Monster
{
    public override void Attack()
    {
        StartCoroutine(LeechSeed());
    }


    IEnumerator LeechSeed()
    {
        yield return null;
        for (int i = 0; i < 3; i++)
        {
            Shoot(transform.position - new Vector3(0f, 0.5f, 0f), 6f, -180, 1);
            yield return new WaitForSeconds(0.1f);
        }
    }
}
