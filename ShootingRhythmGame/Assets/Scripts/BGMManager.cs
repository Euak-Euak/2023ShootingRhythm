using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMManager : MonoBehaviour
{
    static public int Bpm;

    static public bool _isMusicStart;

    [SerializeField] private AudioClip _bgm;
    static public AudioSource MusicPlayer;

    
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
        _isMusicStart = false;
        MusicPlayer = GetComponent<AudioSource>();
        MusicPlayer.clip = _bgm;
    }


    void Update()
    {

    }


    public void MusicStart()
    {
        if (!_isMusicStart)
        {
            MusicPlayer.Play();
            _isMusicStart = true;
        }
    }
}
