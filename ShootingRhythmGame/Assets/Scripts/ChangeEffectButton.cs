using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeEffectButton : MonoBehaviour
{
    void Start()
    {
        SceneChangeEffect.Instance.Out();
    }

    public void Enter()
    {
        
        SceneChangeEffect.Instance.Enter();
    }
}
