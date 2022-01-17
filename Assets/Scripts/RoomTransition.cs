using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTransition : MonoBehaviour
{
    private CameraController cameraControl;
    private Vector3 cameraNorth = new Vector3(0, 11, 0);
    private Vector3 cameraEast = new Vector3(16, 0, 0);
    private Vector3 cameraSouth = new Vector3(0, -11, 0);
    private Vector3 cameraWest = new Vector3(-16, 0, 0);

    private Vector3 playerNorth = new Vector3(0, 1.75f, 0);
    private Vector3 playerEast = new Vector3(1.75f, 0, 0);
    private Vector3 playerSouth = new Vector3(0, -1.75f, 0);
    private Vector3 playerWest = new Vector3(-1.75f, 0, 0);

    // Start is called before the first frame update
    void Start()
    {
        cameraControl = Camera.main.GetComponent<CameraController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerController playerControl = other.GetComponent<PlayerController>();

            if (ArrowKeyMovement.player_control)
            {
                Debug.Log("Do transition");
                other.GetComponent<Rigidbody>().velocity = Vector3.zero;
                other.GetComponent<Animator>().speed = 0.0f;                

                if (this.CompareTag("NorthDoor"))
                {
                    other.transform.position = transform.position - new Vector3(0, 0.5f, 0);
                    StartCoroutine(playerControl.PlayerRoomTransition(playerNorth));
                    StartCoroutine(cameraControl.CameraRoomTransition(cameraNorth));
                }
                else if (this.CompareTag("EastDoor"))
                {
                    other.transform.position = transform.position - new Vector3(0.5f, 0, 0);
                    StartCoroutine(playerControl.PlayerRoomTransition(playerEast));
                    StartCoroutine(cameraControl.CameraRoomTransition(cameraEast));
                }
                else if (this.CompareTag("SouthDoor"))
                {
                    other.transform.position = transform.position - new Vector3(0, -0.5f, 0);
                    StartCoroutine(playerControl.PlayerRoomTransition(playerSouth));
                    StartCoroutine(cameraControl.CameraRoomTransition(cameraSouth));
                }
                else if (this.CompareTag("WestDoor"))
                {
                    other.transform.position = transform.position - new Vector3(-0.5f, 0, 0);
                    StartCoroutine(playerControl.PlayerRoomTransition(playerWest));
                    StartCoroutine(cameraControl.CameraRoomTransition(cameraWest));
                }
            }
            else
            {
                Debug.Log("Transition already happening, don't do anything");
            }
        }
    }
}
