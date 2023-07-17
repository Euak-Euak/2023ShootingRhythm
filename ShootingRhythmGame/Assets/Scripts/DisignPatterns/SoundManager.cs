using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : Singleton<SoundManager>
{
    // 사운드 가져오기
    private Dictionary<string, AudioClip> _audioClips;

    // BGM
    AudioSource _BGMSource = null;
    // SFX
    List<AudioSource> _SFXSource = null;

    [SerializeField] Slider BGM;
    [SerializeField] Slider SFX;

    void Start()
    {
        // 초기화
        _audioClips = new Dictionary<string, AudioClip>();
        _SFXSource = new List<AudioSource>();

        // 사운드 가져오기
        AudioClip[] temp = Resources.LoadAll<AudioClip>(ConstData.Sound);

        // 사운드 추가
        foreach (AudioClip a in temp)
            _audioClips.Add(a.name, a);

        // BGM 소스 추가
        _BGMSource = transform.GetChild(0).GetComponent<AudioSource>();

        // SFX 소스 추가
        int childCount = transform.childCount;
        for (int i = 1; i < childCount; i++)
            _SFXSource.Add(transform.GetChild(i).GetComponent<AudioSource>());

        // BGM 반복
        _BGMSource.loop = true;

        if (PlayerPrefs.HasKey(ConstData.BGMVolume))
        {
            _BGMSource.volume = PlayerPrefs.GetFloat(ConstData.BGMVolume);

            float volume = PlayerPrefs.GetFloat(ConstData.SFXVolume);

            foreach (AudioSource a in _SFXSource)
                a.volume = volume;

            BGM.value = _BGMSource.volume;
            SFX.value = volume;

            SoundManager.Instance.BGMPlay("Main");
        }
    }

    public void OnApplicationQuit()
    {
        // 볼륨 저장
        PlayerPrefs.SetFloat(ConstData.BGMVolume, _BGMSource.volume);
        PlayerPrefs.SetFloat(ConstData.SFXVolume, _SFXSource[0].volume);
    }

    public void BGMPlay(string soundName)
    {
        _BGMSource.clip = _audioClips[soundName];
        _BGMSource.Play();
    }

    public void SFXPlay(string soundName)
    {
        foreach (AudioSource a in _SFXSource)
        {
            if (a.isPlaying)
                continue;

            a.clip = _audioClips[soundName];
            a.Play();
            break;
        }
    }

    public void SFXBolum(float value)
    {
        foreach (AudioSource a in _SFXSource)
        {
            a.volume = value;
        }
    }
    public void BGMBolum(float value)
    {
        _BGMSource.volume = value;
    }

}
