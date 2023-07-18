using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetVolume : MonoBehaviour
{
    public void SetBGMVolume(float value)
    {
        SoundManager.Instance.BGMVolume(Mathf.Log10(value) * 20);
    }
}
