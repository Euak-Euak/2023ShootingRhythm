using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : Attackable
{
    public override void Dead()
    {
        Debug.Log("플레이어 충돌 당함");
    }
}
