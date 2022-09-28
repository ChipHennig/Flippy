using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OnExit : MonoBehaviour
{
    public string sceneToLoad;

    public string keyToPress;

    bool inDoor = false;

    void Update()
    {
        if (Input.GetKeyDown(keyToPress) && inDoor)
        {
            SceneManager.LoadScene(sceneToLoad);
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            inDoor = true;
        }
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            inDoor = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            inDoor = false;
        }
    }
}
