using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LV1RM2Bound : MonoBehaviour, Bounds
{
    public bool boundsExist;

    public Vector2 minCameraPos;
    public Vector2 maxCameraPos;

    private float dialogTime = 8f;

    public GameObject player;
    public GameObject floopy;
    public GameObject door;

    private bool floopyDisappear = false;

    public GameObject crab;
    public GameObject crab2;
    public GameObject crab3;
    public GameObject crab4;


    // Start is called before the first frame update
    void Start()
    {
        door.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(dialogTime > 0)
        {
            dialogTime -= Time.deltaTime;
            player.GetComponent<PlayerController>().ableToMove = false;

        } else
        {
            if (!floopyDisappear)
            {
                player.GetComponent<PlayerController>().ableToMove = true;
                Destroy(floopy);
                player.transform.Rotate(0, 0, 180);
                crab.transform.Rotate(0, 0, 180);
                crab2.transform.Rotate(0, 0, 180);
                crab3.transform.Rotate(0, 0, 180);
                crab4.transform.Rotate(0, 0, 180);

                floopyDisappear = true;
            }
        }

        if(crab == null && crab2 == null && crab3 == null && crab4 == null)
        {
            door.SetActive(true);
        }
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
