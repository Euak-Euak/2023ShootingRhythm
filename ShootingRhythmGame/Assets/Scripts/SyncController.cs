using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SyncController : MonoBehaviour
{
    [SerializeField] private GameObject[] _judgementZones;
    private List<BoxCollider2D> _colliders = new List<BoxCollider2D>();
    [Range(-100, 100)] public float Sync;


    void Start()
    {
        for (int i = 0; i < _judgementZones.Length; i++)
        {
            _colliders.Add(_judgementZones[i].GetComponent<BoxCollider2D>());
        }
    }


    void Update()
    {
        for (int i = 0; i < _judgementZones.Length; i++)
        {
            //ÈæÈæ¾¾¹ß
            _colliders[i].offset = new Vector2(Sync * NoteSpawner.NoteSpeed *  60 / BGMManager.Bpm, 0);
        }
    }
}
