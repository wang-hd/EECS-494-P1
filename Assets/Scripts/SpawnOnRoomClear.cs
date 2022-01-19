using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnOnRoomClear : MonoBehaviour
{
    public AudioClip keySpawnSound;
    private bool enemiesDefeated;

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

            if (enemies.Length <= 0) break;

            yield return null;
        }
    }
}
