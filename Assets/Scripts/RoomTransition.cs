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
    private string north = "n";
    private string east = "e";
    private string south = "s";
    private string west = "w";
    private string empty = "";

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
        if (other.CompareTag("player"))
        {
            PlayerController playerControl = other.GetComponent<PlayerController>();

            if (ArrowKeyMovement.player_control)
            {
                Debug.Log("Do transition");
                other.GetComponent<Rigidbody>().velocity = Vector3.zero;          

                if (this.CompareTag("NorthDoor"))
                {
                    if (playerControl.getPrevTransition() != south)
                    {
                        other.transform.position = transform.position - new Vector3(0, 0.5f, 0);
                        StartCoroutine(playerControl.PlayerRoomTransition(playerNorth));
                        StartCoroutine(cameraControl.CameraRoomTransition(cameraNorth));
                        playerControl.setPrevTransition(north);
                    }
                    else
                    {
                        playerControl.setPrevTransition(empty);
                    }
                }
                else if (this.CompareTag("EastDoor"))
                {
                    if (playerControl.getPrevTransition() != west)
                    {
                        other.transform.position = transform.position - new Vector3(0.5f, 0, 0);
                        StartCoroutine(playerControl.PlayerRoomTransition(playerEast));
                        StartCoroutine(cameraControl.CameraRoomTransition(cameraEast));
                        playerControl.setPrevTransition(east);
                    }
                    else
                    {
                        playerControl.setPrevTransition(empty);
                    }
                }
                else if (this.CompareTag("SouthDoor"))
                {
                    if (playerControl.getPrevTransition() != north)
                    {
                        other.transform.position = transform.position - new Vector3(0, -0.5f, 0);
                        StartCoroutine(playerControl.PlayerRoomTransition(playerSouth));
                        StartCoroutine(cameraControl.CameraRoomTransition(cameraSouth));
                        playerControl.setPrevTransition(south);
                    }
                    else
                    {
                        playerControl.setPrevTransition(empty);
                    }
                }
                else if (this.CompareTag("WestDoor"))
                {
                    if (playerControl.getPrevTransition() != east)
                    {
                        other.transform.position = transform.position - new Vector3(-0.5f, 0, 0);
                        StartCoroutine(playerControl.PlayerRoomTransition(playerWest));
                        StartCoroutine(cameraControl.CameraRoomTransition(cameraWest));
                        playerControl.setPrevTransition(west);
                    }
                    else
                    {
                        playerControl.setPrevTransition(empty);
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
