using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestAttackable : Attackable
{
    public override void Attacked(int damage)
    {
        Debug.Log("플레이어 처맞음");
    }
    public override void Dead()
    {
        throw new System.NotImplementedException();
    }
}
