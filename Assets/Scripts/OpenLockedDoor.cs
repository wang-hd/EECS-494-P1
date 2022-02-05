using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenLockedDoor : MonoBehaviour
{
    public AudioClip doorOpenSound;
    int roomNumber;
    

    private void Start() 
    {
        if (transform.position == new Vector3 (30f, 27f, 0f)) roomNumber = 1;
        else if (transform.position == new Vector3 (17f, 38f, 0f)) roomNumber = 2;
        else if (transform.position == new Vector3(78f, 49f, 0f)) roomNumber = 3;
        else roomNumber = 0;
        Debug.Log(roomNumber);
    }

    private void Update() {
        if (GameController.isEnemyCleared(roomNumber) && GameController.RequirementAchieved(roomNumber))
        {
            AudioSource.PlayClipAtPoint(doorOpenSound, Camera.main.transform.position);
            Destroy(gameObject);
        }
    }

}
