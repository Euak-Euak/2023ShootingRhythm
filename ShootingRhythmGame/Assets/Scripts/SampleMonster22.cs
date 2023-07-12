using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SampleMonster22 : Monster
{
    [SerializeField]
    Sprite _sprite;

    private void Start()
    {
        StartCoroutine(a());
    }
    IEnumerator a()
    {
        yield return null;
        float time = 10f;
            Beam(transform.position + Vector3.down * 5, 180, 1, 0.5f, time, _sprite);
    }

    public override void Attack()
    {
    }
}
