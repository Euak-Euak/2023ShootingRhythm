using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillInventory : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> _skill;

    [SerializeField]
    private List<Text> _use;

    [SerializeField]
    private List<Button> _useSkill;

    void Start()
    {
        for (int i = 0; i < PlayerDataManager.Instance._haveSkill.Count; i++)
        {
            _skill[PlayerDataManager.Instance._haveSkill[i] - 1].SetActive(true);
        }

        for (int i = 0; i < PlayerDataManager.Instance._useSkill.Count; i++)
        {
            DataManager.Instance.OpenDB();
            _use[i].text = DataManager.Instance.SkillName(PlayerDataManager.Instance._useSkill[i]);
            DataManager.Instance.CloseDB();
            _useSkill[i].onClick.AddListener(() => { CancleUseSkill(PlayerDataManager.Instance._useSkill[i], i); });
        }
    }

    public void AddUseSkill(int ID)
    {
        if (PlayerDataManager.Instance._useSkill.Count >= 4)
            return;

        _skill[ID - 1].SetActive(false);

        DataManager.Instance.OpenDB();
        _useSkill[PlayerDataManager.Instance._useSkill.Count].onClick.RemoveAllListeners();
        int index = PlayerDataManager.Instance._useSkill.Count;
        _useSkill[PlayerDataManager.Instance._useSkill.Count].onClick.AddListener(() => { CancleUseSkill(ID, index); });
        _use[PlayerDataManager.Instance._useSkill.Count].text = DataManager.Instance.SkillName(ID);
        PlayerDataManager.Instance._useSkill.Add(ID);
        PlayerDataManager.Instance._haveSkill.Remove(ID);
        DataManager.Instance.CloseDB();
    }

    public void CancleUseSkill(int ID, int index)
    {
        _skill[ID - 1].SetActive(true);

        PlayerDataManager.Instance._useSkill.Remove(ID);
        PlayerDataManager.Instance._haveSkill.Add(ID);
        _use[index].text = "";
    }
}
