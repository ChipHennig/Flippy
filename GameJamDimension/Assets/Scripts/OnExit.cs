using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OnExit : MonoBehaviour
{
    public string sceneToLoad;

    public string keyToPress;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            if(Input.GetKeyDown(keyToPress)) {
                SceneManager.LoadScene(sceneToLoad); 
            }
        }
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (Input.GetKeyDown(keyToPress))
            {
                SceneManager.LoadScene(sceneToLoad);
            }
        }
    }

}
