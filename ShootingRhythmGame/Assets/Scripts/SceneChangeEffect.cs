using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneChangeEffect : Singleton<SceneChangeEffect>
{
    private Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void Enter()
    {
        animator.SetTrigger("Enter");
    }

    public void Out()
    {
        animator.SetTrigger("Out");
    }
}
