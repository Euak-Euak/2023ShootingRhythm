using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Title : MonoBehaviour
{
    static private bool _isFistAccess = true;
    [SerializeField] private GameObject _skipText;
    [SerializeField] private GameObject _cutScene;

    [SerializeField] private GameObject _title;
    [SerializeField] private GameObject _option;
    private bool isIntroEnd = false;


    void Start()
    {
        if (_isFistAccess)
        {
            StartCoroutine("BlinkSkipText");
            _isFistAccess = false;

        }
        else
        {
            _skipText.SetActive(false);
            _cutScene.SetActive(false);
            _title.SetActive(true);
        }
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StopCoroutine("BlinkSkipText");
            _skipText.SetActive(false);
            _cutScene.SetActive(false);
            _title.SetActive(true);
        }
    }


    public void PreesStartBtn()
    {
        SceneManager.LoadScene("TempSkillSelect");
    }


    public void PressRearrangementBtn()
    {
        SceneManager.LoadScene("MunjiTestScene");
    }


    public void PressOptionBtn()
    {
        _title.SetActive(false);
        _option.SetActive(true);
    }


    public void PressQuitBtn()
    {
        Application.Quit();
        //UnityEditor.EditorApplication.isPlaying = false;
    }


    public void PressBackBtn()
    {
        _option.SetActive(false);
        _title.SetActive(true);
    }


    public void PressSyncSettingBtn()
    {
        SceneManager.LoadScene("SyncSettingScene");
    }


    IEnumerator BlinkSkipText()
    {
        bool isActive = true;
        while (!isIntroEnd)
        {
            _skipText.SetActive(isActive);
            isActive = !isActive;
            yield return new WaitForSeconds(0.7f);
        }
    }
}
