using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Attackable : MonoBehaviour
{
    [SerializeField]
    private int _maxHp;
    public int _hp;

    protected void Awake()
    {
        _hp = _maxHp;
    }

    public virtual void Attacked(int damage)
    {
        _hp -= damage;

        if (_hp <= 0)
            Dead();
    }

    public abstract void Dead();
}
