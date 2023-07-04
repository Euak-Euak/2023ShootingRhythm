using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteSpawner : MonoBehaviour
{
    private int _bpm;
    private float _beatInterval;

    [SerializeField]
    private GameObject _note;


    void Start()
    {
        _bpm = BGMManager.Bpm;
        _beatInterval = 30 / (float)_bpm;

        for (int i = 0; i < 64; i++)
        {
            StartCoroutine(MakeNoteCor(i));
        }
    }


    IEnumerator MakeNoteCor(int order)
    {
        yield return new WaitForSeconds(2f + order * _beatInterval);

        MakeNote(_note, order);
    }


    private void MakeNote(GameObject note, int order)
    {
        if (order % 2 != 0)
        {
            note.transform.localScale = new Vector3(0.7f, 0.7f, 1f);
        }
        else
        {
            note.transform.localScale = Vector3.one;
        }
        Instantiate(note, this.transform); //À½¤»¤»
    }


    void Update()
    {

    }
}
