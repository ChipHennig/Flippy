using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lv1Rm1Bound : MonoBehaviour , Bounds
{
    public GameObject player;
    public GameObject arrowTwo;

    public Text firstText;
    public Text secondText;
    public Text thirdText;
    public Text fourthText;

    public bool boundsExist;

    public Vector2 minCameraPos;
    public Vector2 maxCameraPos;

    public GameObject crab1;
    public GameObject crab2;

    public GameObject tempBound;

    private bool secondTextOnce = true;
    private bool thirdTextOnce = true;
    private bool fourthTextOnce = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (crab1 == null && crab2 == null)
        {
            if (secondTextOnce)
            {
                Destroy(tempBound);
                maxCameraPos = new Vector2(78, -50);
                //Display message to go right!
                firstText.gameObject.SetActive(false);
                secondText.gameObject.SetActive(true);
                secondTextOnce = false;
                arrowTwo.SetActive(true);
            }
        }

        if(thirdTextOnce)
        {
            if(player.transform.position.x > 25)
            {
                secondText.gameObject.SetActive(false);
                thirdText.gameObject.SetActive(true);
                thirdTextOnce = false;
            }
        }

        if(fourthTextOnce)
        {
            if(player.transform.position.x > 76)
            {
                thirdText.gameObject.SetActive(false);
                fourthText.gameObject.SetActive(true);
            }
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
