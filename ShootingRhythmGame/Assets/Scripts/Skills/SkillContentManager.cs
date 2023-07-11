using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillContentManager : MonoBehaviour
{
    [SerializeField] GameObject _gameObject;
    [SerializeField] SkilInfo _skillInfo;

    private Dictionary<int, SkillContent> _skillInfoByID = new Dictionary<int, SkillContent>();

    void Start()
    {
        DataManager.Instance.OpenDB();
        for (int i = 1; i <= DataManager.Instance.SkillCount(); i++)
        {
            SkillContent skill = Instantiate(_gameObject).GetComponent<SkillContent>();
            skill.transform.SetParent(transform, false);
            skill.Init(i, _skillInfo.UpdateInfo);
            _skillInfoByID.Add(i, skill);
        }
        DataManager.Instance.CloseDB();

        _skillInfo.GetSkillInfoDictionary(_skillInfoByID);
    }
    
}
