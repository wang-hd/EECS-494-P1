using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallTriggerController : MonoBehaviour
{
    public GameObject wallmaster;
    public int wallside = 0;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other) {
        if (GameController.wallmasterCount > 0 && other.CompareTag("player"))
        {
            Vector3 spawnPosition = other.transform.position;
            if (wallside == 0)
            {
                spawnPosition.y += 1;
                spawnPosition.x -= 3;
            }
            else if (wallside == 1)
            {
                spawnPosition.x += 1;
                spawnPosition.y += 3;
            }
            else if (wallside == 2)
            {
                spawnPosition.y -= 1;
                spawnPosition.x -= 3;
            }
            else if (wallside == 3)
            {
                spawnPosition.x -= 1;
                spawnPosition.y += 3;
            }
            Instantiate(wallmaster, spawnPosition, Quaternion.identity);
            GameController.alterWallmasterCount(-1);
        }
        
    }
}
