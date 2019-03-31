using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnItem : MonoBehaviour
{
    public GameObject item;
    private Transform player;

    public void SpawnDroppedItem()
    {
        int distanceFromPlayer = 3;
        Vector2 playerPos = new Vector2(player.position.x, player.position.y + distanceFromPlayer);
        Instantiate(item, playerPos, Quaternion.identity); //Quaternion.identity so item spawns with 0 rotation
    }
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
