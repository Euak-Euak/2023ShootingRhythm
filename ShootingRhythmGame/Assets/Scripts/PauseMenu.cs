using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : PauseOnStage
{
    [SerializeField] private GameObject[] _PauseMenuBtn;
    [SerializeField] private GameObject _optionMenu;
    private GameObject nowPage;


    public void PressResumeBtn()
    {
        OnResumeGame();
    }


    public void PressRetryBtn()
    {
        OnResumeGame();
        Destroy(GameObject.Find("BulletManager"));
        SceneManager.LoadScene("Rhythm");
    }


    public void PressOptionBtn()
    {
        nowPage = _optionMenu;

        _optionMenu.SetActive(true);
        _pauseMenu.SetActive(false);
    }


    public void PressQuitBtn()
    {
        OnResumeGame();
        tempSkillSelect.SelectedSkillIdList.Clear();
        Destroy(GameObject.Find("BulletManager"));
        Destroy(GameObject.Find("DataManager"));
        SceneManager.LoadScene("TempSkillSelect");
    }


    public void ReturnPauseMenu()
    {
        nowPage.SetActive(false);
        _pauseMenu.SetActive(true);
    }
}
