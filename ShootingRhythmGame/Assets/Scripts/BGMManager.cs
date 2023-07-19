using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMManager : MonoBehaviour
{
    static public int Bpm = 120;
    static public string _bgmName;

    static public bool _isMusicStart;


    private void Awake()
    {
        switch (PlayerDataManager.Instance.RoundType)
        {
              case GameRoundType.Stage1Field:
              case GameRoundType.Stage2Field:
              case GameRoundType.Stage3Field:
              case GameRoundType.Stage4Field:
              case GameRoundType.Stage5Field:
                  _bgmName = "Idonthaveanymusic";
                  Bpm = 130;
                  break;

              case GameRoundType.Stage1Boss:
                  _bgmName = "Idonthaveanymusic";
                  Bpm = 260;
                  break;
              case GameRoundType.Stage2Boss:
                  _bgmName = "Idonthaveanymusic";
                  Bpm = 260;
                  break;
              case GameRoundType.Stage3Boss:
                  _bgmName = "Idonthaveanymusic";
                  Bpm = 260;
                  break;
              case GameRoundType.Stage4Boss:
                  _bgmName = "Idonthaveanymusic";
                  Bpm = 260;
                  break;
              case GameRoundType.Stage5Boss:
                  _bgmName = "Idonthaveanymusic";
         Bpm = 130;
         break;
        }
        Debug.Log(Bpm);
    }

    void Start()
    {
        SoundManager.Instance.BGMStop();
        _isMusicStart = false;
    }


    public void MusicStart()
    {
        if (!_isMusicStart)
        {
            SoundManager.Instance.BGMPlay(_bgmName);
            _isMusicStart = true;
        }
    }


    public void Mute(float duration)
    {
        StartCoroutine(MuteCor(duration));
    }

    IEnumerator MuteCor(float duration)
    {
        SoundManager.Instance.MuteSound(true);
        yield return new WaitForSeconds(duration);
        SoundManager.Instance.MuteSound(false);
    }
}
