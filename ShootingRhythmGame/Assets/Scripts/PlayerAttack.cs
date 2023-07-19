using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAttack : Attackable
{
    [SerializeField]
    private Slider _hpBar;

    [SerializeField]
    private Transform _transform;
    [SerializeField]
    private SpriteRenderer _sprite;
    [SerializeField]
    private Transform _start;

    private bool _isAttackedAble = true;

    private void Start()
    {
        _hp = PlayerDataManager.Instance.PlayerHP;
        _hpBar.value = _hp;
    }

    public override void Dead()
    {
        SceneChangeEffect.Instance.Enter();
        StartCoroutine(DeadC());
    }
    IEnumerator DeadC()
    {
        yield return new WaitForSeconds(3f);
        SceneLoadManager.LoadScene("EndScene");
    }

    public override void Attacked(int damage)
    {

        if (!_isAttackedAble)
            return;

        base.Attacked(damage);

        _hpBar.value = _hp;

        PlayerDataManager.Instance.PlayerHP = _hp;
        StartCoroutine(ReStart());
    }

    IEnumerator ReStart()
    {
        float t = 0f;

        Vector2 start = _transform.position;

        _hpBar.value = _hp;
        
        _isAttackedAble = false;
        _sprite.color = new Color(1, 1, 1, 0.5f);
        while (t < 1.5f)
        {
            t += Time.deltaTime;
            _transform.position = Vector3.Lerp(start, _start.position, t);
            yield return null;
        }

        yield return new WaitForSeconds(PlayerDataManager.Instance.InvincibilityTime);
        _sprite.color = Color.white;

        _isAttackedAble = true;
    }
}
