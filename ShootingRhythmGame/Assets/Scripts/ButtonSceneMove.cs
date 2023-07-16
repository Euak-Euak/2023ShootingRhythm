using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSceneMove : MonoBehaviour
{
    public void LoadScene(string name)
    {
        SceneLoadManager.LoadScene(name);
    }
}
