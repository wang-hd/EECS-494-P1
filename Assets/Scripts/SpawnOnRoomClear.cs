using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnOnRoomClear : MonoBehaviour
{
    public AudioClip keySpawnSound;
    private bool enemiesDefeated = false;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(WaitForEnemiesDefeated());
    }

    // Update is called once per frame
    void Update()
    {
        if (enemiesDefeated) {
            // Spawn key gameObject in a random location in the current room
        }
    }

    IEnumerator WaitForEnemiesDefeated()
    {
        while (true)
        {
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("enemy");
            List<GameObject> enemiesInCurrentRoom = new List<GameObject>();
            foreach (GameObject enemy in enemies)
            {
                if (CoroutineUtilities.InCurrentRoom(enemy.transform.position, Camera.main.transform.position))
                {
                    enemiesInCurrentRoom.Add(enemy);
                }
            }

            if (enemiesInCurrentRoom.Count <= 0) 
            {
                enemiesDefeated = true;
                break;
            }

            yield return null;
        }
    }
}
