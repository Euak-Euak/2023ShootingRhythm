using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetVolume : MonoBehaviour
{
    [SerializeField] private Slider _BGMSlider;
    [SerializeField] private Slider _SFXSlider;

    private void Start()
    {
        _BGMSlider.value = SoundManager.Instance.Volume("BGM");
        _SFXSlider.value = SoundManager.Instance.Volume("SFX");
    }

    public void SetBGMVolume(float value)
    {
        SoundManager.Instance.BGMVolume(value);
    }

    public void SetSFXVolume(float value)
    {
        SoundManager.Instance.SFXVolume(value); //
    }
}
