using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestAttackable : Attackable
{
    public override void Attacked(int damage)
    {
        Debug.Log("�÷��̾� ó����");
    }
    public override void Dead()
    {
        throw new System.NotImplementedException();
    }
}
