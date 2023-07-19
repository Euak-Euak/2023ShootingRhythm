using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseOnStage : MonoBehaviour
{
    static public bool IsPause = false;

    [SerializeField] protected GameObject _pause;
    [SerializeField] protected GameObject _pauseMenu;
    protected AudioSource _bgm;

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!IsPause)
            {
                OnPauseGame();
            }
        }
    }


    public void OnPauseGame()
    {
        _pause.SetActive(true);

        Time.timeScale = 0f;
        SoundManager.Instance.BGMPause();
        IsPause = true;
    }


    public void OnResumeGame()
    {
        _pause.SetActive(false);

        Time.timeScale = 1f;
        SoundManager.Instance.BGMPlay(BGMManager.BgmName);
        IsPause = false;
    }
}
