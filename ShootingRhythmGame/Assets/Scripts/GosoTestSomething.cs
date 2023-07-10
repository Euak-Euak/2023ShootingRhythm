using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GosoTestSomething : MonoBehaviour
{

    void Start()
    {
        
    }
    

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (this.gameObject.name == "Canvas")
            {
                //Destroy(this.gameObject);
                SceneManager.LoadScene("GosorPwlfkf");
            }
            else if (this.gameObject.name == "Camera")
            {
                SceneManager.LoadScene("Rhythm");
            }
        }
    }
}
