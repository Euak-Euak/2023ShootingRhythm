using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSceneMove : MonoBehaviour
{
    public void LoadScene(string name)
    {
        SceneLoadManager.LoadScene(name);
    }

    public void LoadSceneD(string name)
    {
        StartCoroutine(D(name));
    }

    private IEnumerator D(string name)
    {
        yield return new WaitForSeconds(3f);
        SceneLoadManager.LoadScene(name);
    }

    public void OnOffPopup(GameObject obj)
    {
        obj.SetActive(!obj.activeSelf);
    }
}
