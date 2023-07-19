using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMManager : MonoBehaviour
{
    [SerializeField] private bool _isGame;
    static public int Bpm = 120;
    [SerializeField] private string _bgmName;
    static public string BgmName;

    static public bool _isMusicStartOnStage;


    private void Awake()
    {
        if (_isGame)
        {
            switch (PlayerDataManager.Instance.RoundType)
            {
                case GameRoundType.None: break;

                case GameRoundType.Stage1Field:
                case GameRoundType.Stage2Field:
                case GameRoundType.Stage3Field:
                case GameRoundType.Stage4Field:
                case GameRoundType.Stage5Field:
                    BgmName = "FaceTheStorm-EanGrimm";
                    Bpm = 110;
                    break;

                case GameRoundType.Stage1Boss:
                    BgmName = "Interstellar-RossBugden";
                    Bpm = 120;
                    break;
                case GameRoundType.Stage2Boss:
                    BgmName = "TheWorldMostEpicSeaShanty-AlexanderNakarada";
                    Bpm = 140;
                    break;
                case GameRoundType.Stage3Boss:
                    BgmName = "CircusThemeTrapVer-AlexanderNakarada";
                    Bpm = 119;
                    break;
                case GameRoundType.Stage4Boss:
                    BgmName = "DeadMan'sOpera-SilenCyde";
                    Bpm = 140;
                    break;
                case GameRoundType.Stage5Boss:
                    BgmName = "Idonthaveanymusic";
                    Bpm = 130;
                    break;
            }

            SoundManager.Instance.BGMStop();
            _isMusicStartOnStage = false;
        }
        //else BgmName = "Main"; // _bgmName;
        else BgmName = _bgmName;
    }

    private void Start() //스테이지아닐때만...
    {
        if (!_isGame) SoundManager.Instance.BGMPlay(BgmName);
    }


    public void MusicStart() //스테이지에서만..
    {
        if (!_isMusicStartOnStage)
        {
            SoundManager.Instance.BGMPlay(BgmName);
            _isMusicStartOnStage = true;
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
