using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTip : MonoBehaviour
{
    Text text;

    [SerializeField]
    List<string> strings;
    void Start()
    {
        text = GetComponent<Text>();
        text.text = strings[Random.Range(0, strings.Count)];
    }
}
