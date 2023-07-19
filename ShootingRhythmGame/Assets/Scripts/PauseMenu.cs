using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : PauseOnStage
{
    [SerializeField] private GameObject _optionMenu;
    private GameObject nowPage;


    public void PressResumeBtn()
    {
        OnResumeGame();
    }


    public void PressRetryBtn()
    {
        initOnMoveScene("Main");
        SceneManager.LoadScene("RewardScene");
    }


    public void PressOptionBtn()
    {
        _optionMenu.SetActive(true);
        _pauseMenu.SetActive(false);
    }


    public void PressQuitBtn()
    {
        initOnMoveScene("Main");
        SceneManager.LoadScene("SampleTitleScene");
    }


    public void ReturnPauseMenu()
    {
        _optionMenu.SetActive(false);
        _pauseMenu.SetActive(true);
    }

    private void initOnMoveScene(string bgm)
    {
        OnResumeGame();
        Destroy(GameObject.Find("BulletManager"));
        PlayerDataManager.Instance._useSkill.Clear();
        PlayerDataManager.Instance._haveSkill.Clear();
        PlayerDataManager.Instance.RoundType = GameRoundType.None;
        SoundManager.Instance.BGMPlay(bgm);
    }
}
