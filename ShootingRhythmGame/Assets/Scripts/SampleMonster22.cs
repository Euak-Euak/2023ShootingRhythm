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
        float time = 10f;
        for (int i = 0; i < 360; i += 10)
        {
            yield return new WaitForSeconds(0.2f);
            Beam(transform.position + Vector3.down * 5, 180 - i, 1, 0.5f, time, _sprite);
            time -= 0.2f;
        }
    }

    public override void Attack()
    {
    }
}
