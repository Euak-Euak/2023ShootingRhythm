using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teeeest : MonoBehaviour
{
    SkillManager manager;
    void Start()
    {
        manager = GetComponent<SkillManager>();
        manager.Init();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            manager.SkillSet[9].SkillUse();
        }
    }
}