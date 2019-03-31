using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroBounds : MonoBehaviour, Bounds
{
    public bool boundsExist;

    public Vector2 minCameraPos;
    public Vector2 maxCameraPos;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void bound()
    {
        if (boundsExist)
        {
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, minCameraPos.x, maxCameraPos.x),
                Mathf.Clamp(transform.position.y, minCameraPos.y, maxCameraPos.y), -10);
        }
    }
}
