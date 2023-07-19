using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteSpawner : MonoBehaviour
{
    [SerializeField] private NoteManager _noteManager;
    [SerializeField] private float _noteSpeed;
    static public float NoteSpeed;

    static public int NoteCnt = 0;
    static public List<bool> IsUsed = new List<bool>();

    private int _beatIndex = 0;
    static public List<bool> Rhythm = new List<bool>() { true };

    // _노트 등장 간격 기준 (4분 음표 1, 8분 음표 0.5, 2분 음표 2 . . . .)
    [SerializeField] private float _beat;
    private float _beatInterval;


    private void Awake()
    {
        Reset();
        NoteSpeed = _noteSpeed;
    }


    void Start()
    {
        //_bpm = BGMManager.Bpm;
        _beatInterval = 60 * _beat / (float)BGMManager.Bpm;

        StartCoroutine(MakeNoteCor());
    }


    IEnumerator MakeNoteCor()
    {
        yield return new WaitForSeconds(0.1f);

        bool half = false;
        while (true)
        {
            yield return new WaitForSeconds(_beatInterval);
            if (Rhythm[_beatIndex])
            {
                MakeNote(half);
            }

            half = !half;
            if (_beatIndex == Rhythm.Count - 1) _beatIndex = 0;
            else _beatIndex++;
        }
    }


    private void MakeNote(bool order)
    {
        var note = _noteManager.SpawnObject();

        if (order)
        {
            note.transform.localScale = new Vector3(0.7f, 0.7f, 1f);
        }
        else
        {
            note.transform.localScale = Vector3.one;
        }
        IsUsed.Add(false);
        note.Init(transform);
        NoteCnt++;
    }


    void Update()
    {

    }


    private void Reset()
    {
        NoteCnt = 0;
        IsUsed.Clear();
    }
}