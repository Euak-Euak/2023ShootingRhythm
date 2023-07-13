using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMManager : MonoBehaviour
{
    static public int Bpm;

    static public bool _isMusicStart = false;

    [SerializeField] private AudioClip _bgm;
    AudioSource musicPlayer;

    
    private void Awake()
    {
        if (_bgm == null)
        {
            _bgm = Resources.Load<AudioClip>("BGM/Idonthaveanymusic");
            Bpm = 130;
        }
    }

    void Start()
    {
        musicPlayer = GetComponent<AudioSource>();
        musicPlayer.clip = _bgm;
    }


    void Update()
    {

    }


    public void MusicStart()
    {
        if (!_isMusicStart)
        {
            musicPlayer.Play();
            _isMusicStart = true;
        }
    }
}
