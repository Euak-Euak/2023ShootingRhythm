using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SyncSettingScene : MonoBehaviour
{
    static public string BeforeScene;
    [SerializeField] private Text _curSyncText;
    

    void Start()
    {
        _curSyncText = _curSyncText.GetComponent<Text>();
    }


    void Update()
    {
        _curSyncText.text = SyncController.Sync.ToString();

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (-0.3 < SyncController.Sync)
            {
                PressLateBtn();
            }
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            if (SyncController.Sync < 0.3)
            {
                PressEarlyBtn();
            }
        }
    }


    public void PressEarlyBtn()
    {
        SyncController.Sync += 0.0002f;
    }


    public void PressLateBtn()
    {
        SyncController.Sync -= 0.0002f;
    }


    public void PressBackBtn()
    {
        SceneManager.LoadScene(BeforeScene);
    }
}
