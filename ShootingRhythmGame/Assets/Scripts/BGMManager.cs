using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMManager : MonoBehaviour
{
    static public int Bpm;

    static public bool _isMusicStart = false;

    private AudioClip _bgm;
    AudioSource musicPlayer;

    
    private void Awake()
    {
        Bpm = 130;
    }

    void Start()
    {
        _bgm = Resources.Load<AudioClip>("BGM/Idonthaveanymusic");

        musicPlayer = GetComponent<AudioSource>();
        musicPlayer.clip = _bgm;
    }


    void Update()
    {

    }


    public void MusicStart()
    {
        musicPlayer.Play();
    }
}
