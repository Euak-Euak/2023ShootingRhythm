using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Attackable : MonoBehaviour
{
    private int _hp;

    public void Attacked(int damage)
    {
        _hp -= damage;

        if (_hp <= 0)
            Dead();
    }

    public abstract void Dead();
}
