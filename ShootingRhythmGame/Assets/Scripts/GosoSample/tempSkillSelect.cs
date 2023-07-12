using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tempSkillSelect : MonoBehaviour
{
    private int _max = 4;
    static public List<int> SelectedSkillIdList = new List<int>();
    static protected bool IsSelectionMax = false;

    [SerializeField] private GameObject _btnParent;
    protected SkillManager _skillManager;


    void Start()
    {
        for (int i = 0; i < _btnParent.gameObject.transform.childCount; i++)
        {
            _btnParent.transform.GetChild(i).GetComponent<SkillSelectionButton>()._idNum = i + 1;
        }
    }

    void Update()
    {
        if (SelectedSkillIdList.Count >= _max)
        {
            IsSelectionMax = true;
        }
        else IsSelectionMax = false;
    }
}