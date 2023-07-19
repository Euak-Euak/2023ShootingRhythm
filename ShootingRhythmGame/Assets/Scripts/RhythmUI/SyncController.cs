using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SyncController : MonoBehaviour //Singleton<SyncController>
{
    [SerializeField] private GameObject[] _judgementZones;
    private List<BoxCollider2D> _colliders = new List<BoxCollider2D>();
    static public float Sync;


    void Awake()
    {
        for (int i = 0; i < _judgementZones.Length; i++)
        {
            _colliders.Add(_judgementZones[i].GetComponent<BoxCollider2D>());
        }

        if (PlayerPrefs.HasKey(ConstData.Sync))//(PlayerPrefs.GetFloat(ConstData.Sync) != 0)//
        {
            Sync = PlayerPrefs.GetFloat(ConstData.Sync);
        }
    }

    void Update()
    {
        for (int i = 0; i < _judgementZones.Length; i++)
        {
            _colliders[i].offset = new Vector2(Sync * 10 * NoteSpawner.NoteSpeed , 0);
        }
    }

}
