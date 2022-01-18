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

                if (this.CompareTag("NorthDoor"))
                {
                    if (playerControl.prev_transition != "s")
                    {
                        other.transform.position = transform.position - new Vector3(0, 0.5f, 0);
                        StartCoroutine(playerControl.PlayerRoomTransition(playerNorth));
                        StartCoroutine(cameraControl.CameraRoomTransition(cameraNorth));
                        playerControl.prev_transition = "n";
                    }
                    else
                    {
                        playerControl.prev_transition = "";
                    }
                }
                else if (this.CompareTag("EastDoor"))
                {
                    if (playerControl.prev_transition != "w")
                    {
                        other.transform.position = transform.position - new Vector3(0.5f, 0, 0);
                        StartCoroutine(playerControl.PlayerRoomTransition(playerEast));
                        StartCoroutine(cameraControl.CameraRoomTransition(cameraEast));
                        playerControl.prev_transition = "e";
                    }
                    else
                    {
                        playerControl.prev_transition = "";
                    }
                }
                else if (this.CompareTag("SouthDoor"))
                {
                    if (playerControl.prev_transition != "n")
                    {
                        other.transform.position = transform.position - new Vector3(0, -0.5f, 0);
                        StartCoroutine(playerControl.PlayerRoomTransition(playerSouth));
                        StartCoroutine(cameraControl.CameraRoomTransition(cameraSouth));
                        playerControl.prev_transition = "s";
                    }
                    else
                    {
                        playerControl.prev_transition = "";
                    }
                }
                else if (this.CompareTag("WestDoor"))
                {
                    if (playerControl.prev_transition != "e")
                    {
                        other.transform.position = transform.position - new Vector3(-0.5f, 0, 0);
                        StartCoroutine(playerControl.PlayerRoomTransition(playerWest));
                        StartCoroutine(cameraControl.CameraRoomTransition(cameraWest));
                        playerControl.prev_transition = "w";
                    }
                    else
                    {
                        playerControl.prev_transition = "";
                    }
                }                
            }
            else
            {
                Debug.Log("Transition already happening, don't do anything");
            }
        }
    }
}
