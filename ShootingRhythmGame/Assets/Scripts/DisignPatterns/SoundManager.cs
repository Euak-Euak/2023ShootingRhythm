using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : Singleton<SoundManager>
{
    // ���� ��������
    private Dictionary<string, AudioClip> _audioClips;

    // BGM
    AudioSource _BGMSource = null;
    // SFX
    List<AudioSource> _SFXSource = null;

    [SerializeField] Slider BGM;
    [SerializeField] Slider SFX;

    void Start()
    {
        // �ʱ�ȭ
        _audioClips = new Dictionary<string, AudioClip>();
        _SFXSource = new List<AudioSource>();

        // ���� ��������
        AudioClip[] temp = Resources.LoadAll<AudioClip>(ConstData.Sound);

        // ���� �߰�
        foreach (AudioClip a in temp)
            _audioClips.Add(a.name, a);

        // BGM �ҽ� �߰�
        _BGMSource = transform.GetChild(0).GetComponent<AudioSource>();

        // SFX �ҽ� �߰�
        int childCount = transform.childCount;
        for (int i = 1; i < childCount; i++)
            _SFXSource.Add(transform.GetChild(i).GetComponent<AudioSource>());

        // BGM �ݺ�
        _BGMSource.loop = true;

        if (PlayerPrefs.HasKey(ConstData.BGMVolume))
        {
            _BGMSource.volume = PlayerPrefs.GetFloat(ConstData.BGMVolume);

            float volume = PlayerPrefs.GetFloat(ConstData.SFXVolume);

            foreach (AudioSource a in _SFXSource)
                a.volume = volume;

            //BGM.value = _BGMSource.volume;
            //SFX.value = volume;

            BGMPlay("CutScene");
        }
    }

    public void OnApplicationQuit()
    {
        // ���� ����
        PlayerPrefs.SetFloat(ConstData.BGMVolume, _BGMSource.volume);
        PlayerPrefs.SetFloat(ConstData.SFXVolume, _SFXSource[0].volume);
    }

    public void BGMPlay(string soundName)
    {
        _BGMSource.clip = _audioClips[soundName];
        _BGMSource.Play();
    }

    public void BGMPause()
    {
        _BGMSource.Pause();
    }

    public void BGMStop()
    {
        _BGMSource.Stop();
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

    public void SFXVolume(float value)
    {
        foreach (AudioSource a in _SFXSource)
        {
            a.volume = value;
        }
    }
    public void BGMVolume(float value)
    {
        _BGMSource.volume = value;
    }

    public float Volume(string type)
    {
        if (type == "BGM") return _BGMSource.volume;
        else return _SFXSource[0].volume;
    }

    public void MuteSound(bool muteOn)
    {
        _BGMSource.mute = muteOn;
        foreach (AudioSource a in _SFXSource)
        {
            a.mute = muteOn;
        }
    }
}