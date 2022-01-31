using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenLockedDoor : MonoBehaviour
{
    public AudioClip doorOpenSound;
    int roomNumber;
    

    private void Start() 
    {
        if (transform.position == new Vector3 (30, 27, 0)) roomNumber = 1;
        else if (transform.position == new Vector3 (17, 38, 0)) roomNumber = 2;
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
