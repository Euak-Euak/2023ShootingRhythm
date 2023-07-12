using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseOnStage : MonoBehaviour
{
    static public bool IsPause = false;

    [SerializeField] protected GameObject _pause;
    [SerializeField] protected GameObject _pauseMenu;
    protected AudioSource _bgm;


    void Start()
    {
        _bgm = GameObject.Find("Main Camera").GetComponent<AudioSource>();
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!IsPause)
            {
                OnPauseGame();
            }
            //else OnResumeGame();
        }
    }


    public void OnPauseGame()
    {
        _pause.SetActive(true);

        Time.timeScale = 0f;
        _bgm.Pause();
        IsPause = true;
    }


    public void OnResumeGame()
    {
        _pause.SetActive(false);

        Time.timeScale = 1f;
        _bgm.Play();
        IsPause = false;
    }
}
