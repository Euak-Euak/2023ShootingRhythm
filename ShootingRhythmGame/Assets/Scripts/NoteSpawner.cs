using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteSpawner : MonoBehaviour
{
    [SerializeField]
    private NoteManager _noteManager;

    static public int NoteCnt = 0;
    static public List<bool> IsUsed = new List<bool>();

    private int _bpm;
    // _��Ʈ ���� ���� ���� (4�� ��ǥ 1, 8�� ��ǥ 0.5, 2�� ��ǥ 2 . . . .)
    [SerializeField] private int _beat;
    private float _beatInterval;


    void Start()
    {
        _bpm = BGMManager.Bpm;
        _beatInterval = 60 * _beat / (float)_bpm;

        StartCoroutine(MakeNoteCor());
    }


    IEnumerator MakeNoteCor()
    {
        yield return new WaitForSeconds(2);

        bool half = false;
        while (true)
        {
            yield return new WaitForSeconds(_beatInterval);
            
            MakeNote(half);
            half = !half;
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
        NoteCnt++;
        note.Init(transform);
    }


    void Update()
    {

    }
}
