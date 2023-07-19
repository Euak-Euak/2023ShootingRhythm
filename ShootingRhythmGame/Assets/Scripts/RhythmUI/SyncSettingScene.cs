using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SyncSettingScene : MonoBehaviour
{
    [SerializeField] private Text _curSyncText;


    void Start()
    {
        _curSyncText = _curSyncText.GetComponent<Text>();
        SoundManager.Instance.BGMStop();
    }


    void Update()
    {
        _curSyncText.text = SyncController.Sync.ToString();

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (-0.3 < SyncController.Sync)
            {
                Late();
            }
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            if (SyncController.Sync < 0.3)
            {
                Early();
            }
        }
    }


    public void Early()
    {
        SyncController.Sync += 0.0002f;
    }


    public void Late()
    {
        SyncController.Sync -= 0.0002f;
    }

    
    public void ResetSync()
    {
        SyncController.Sync = 0;
    }


    public void SaveSync()
    {
        Debug.Log(SyncController.Sync);
        PlayerPrefs.SetFloat(ConstData.Sync, SyncController.Sync);
    }
}
