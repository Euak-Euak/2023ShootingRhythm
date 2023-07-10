using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tempSkillSelect : MonoBehaviour
{
    public int SelectedSkillCnt;
    public bool IsSelectionMax = false;

    void Start()
    {
        
    }

    void Update()
    {
        Debug.Log(SelectedSkillCnt);
        if (SelectedSkillCnt >= 4)
        {
            IsSelectionMax= true;
        }
    }
}
