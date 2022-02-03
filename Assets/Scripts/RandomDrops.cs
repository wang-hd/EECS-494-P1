using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomDrops : MonoBehaviour
{
    public GameObject rupee;
    public GameObject blue_rupee;
    public GameObject heart;
    public GameObject bomb;
    public string enemyType = "X";

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    private void OnDestroy() 
    {
        if (Random.Range(0, 10) <= 0)
        {
            GameObject loot = GetLoot();
            if (loot != null)
            {
                Instantiate(loot, transform.position, Quaternion.identity);
            }
        }
    }

    GameObject GetLoot()
    {
        if (enemyType == "A")
        {
            // no enemies of this type
        }
        else if (enemyType == "B")
        {
            int rand = Random.Range(0, 10);
            if (rand < 3)
            {
                return rupee;
            }
            else if (rand < 6)
            {
                return heart;
            }
            else
            {
                return bomb;
            }
        }
        else if (enemyType == "C")
        {
            int rand = Random.Range(0, 10);
            if (rand < 5)
            {
                return rupee;
            }
            else if (rand < 8)
            {
                return heart;
            }
            else
            {
                return blue_rupee;
            }
        }
        else if (enemyType == "D")
        {
            int rand = Random.Range(0, 10);
            if (rand < 6)
            {
                return heart;
            }
            else
            {
                return rupee;
            }
        }
        return null;
    }
}
