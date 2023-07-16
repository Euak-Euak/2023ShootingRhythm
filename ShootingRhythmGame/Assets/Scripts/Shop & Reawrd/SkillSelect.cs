using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillSelect : MonoBehaviour
{
    public int _nowSelect = 0;

    public void Select(int id)
    {
        _nowSelect = id;
    }

    public void Decision()
    {
        PlayerDataManager.Instance._haveSkill.Add(_nowSelect);

        PlayerDataManager.Instance._useSkill.Add(_nowSelect);

        SceneLoadManager.LoadScene("GameSceneTest");
    }
}
