using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTransition : MonoBehaviour
{
    Camera cam;
    GameObject player;
    PlayerMovement player_control;
    Animator player_anim;
    readonly Vector3 cameraNorth = new Vector3(0, 11, 0);
    readonly Vector3 cameraEast = new Vector3(16, 0, 0);
    readonly Vector3 cameraSouth = new Vector3(0, -11, 0);
    readonly Vector3 cameraWest = new Vector3(-16, 0, 0);

    readonly Vector3 playerNorth = new Vector3(0, 1.75f, 0);
    readonly Vector3 playerEast = new Vector3(1.75f, 0, 0);
    readonly Vector3 playerSouth = new Vector3(0, -1.75f, 0);
    readonly Vector3 playerWest = new Vector3(-1.75f, 0, 0);
    readonly string north = "n";
    readonly string east = "e";
    readonly string south = "s";
    readonly string west = "w";
    readonly string empty = "";
    static string prevTransition;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        player = GameObject.Find("Player");
        player_control = player.GetComponent<PlayerMovement>();
        player_anim = player.GetComponent<Animator>();
        prevTransition = empty;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("player"))
        {
            if (player_control.enabled)
            {
                Debug.Log("Do transition");
                other.GetComponent<Rigidbody>().velocity = Vector3.zero;          

                if (this.CompareTag("NorthDoor"))
                {
                    if (getPrevTransition() != south)
                    {
                        other.transform.position = transform.position - new Vector3(0, 0.5f, 0);
                        StartCoroutine(PlayerRoomTransition(playerNorth));
                        StartCoroutine(CameraRoomTransition(cameraNorth));
                        setPrevTransition(north);
                    }
                    else
                    {
                        setPrevTransition(empty);
                    }
                }
                else if (this.CompareTag("EastDoor"))
                {
                    if (getPrevTransition() != west)
                    {
                        other.transform.position = transform.position - new Vector3(0.5f, 0, 0);
                        StartCoroutine(PlayerRoomTransition(playerEast));
                        StartCoroutine(CameraRoomTransition(cameraEast));
                        setPrevTransition(east);
                    }
                    else
                    {
                        setPrevTransition(empty);
                    }
                }
                else if (this.CompareTag("SouthDoor"))
                {
                    if (getPrevTransition() != north)
                    {
                        other.transform.position = transform.position - new Vector3(0, -0.5f, 0);
                        StartCoroutine(PlayerRoomTransition(playerSouth));
                        StartCoroutine(CameraRoomTransition(cameraSouth));
                        setPrevTransition(south);
                    }
                    else
                    {
                        setPrevTransition(empty);
                    }
                }
                else if (this.CompareTag("WestDoor"))
                {
                    if (getPrevTransition() != east)
                    {
                        other.transform.position = transform.position - new Vector3(-0.5f, 0, 0);
                        StartCoroutine(PlayerRoomTransition(playerWest));
                        StartCoroutine(CameraRoomTransition(cameraWest));
                        setPrevTransition(west);
                    }
                    else
                    {
                        setPrevTransition(empty);
                    }
                }                
            }
            else
            {
                Debug.Log("Transition already happening, don't do anything");
            }
        }
    }

    IEnumerator CameraRoomTransition(Vector3 direction)
    {
        // Wait for player to finish moving into the doorway
        yield return new WaitForSeconds(0.75f);

        Debug.Log("Moving camera");
        Vector3 initial_position = cam.transform.position;
        Vector3 final_position = cam.transform.position + direction;

        /* Transition to new "room" */
        yield return StartCoroutine(
            CoroutineUtilities.MoveObjectOverTime(cam.transform, initial_position, final_position, 1.75f)
        );
    }

    IEnumerator PlayerRoomTransition(Vector3 direction)
    {
        player_control.enabled = false;
        player.GetComponent<BoxCollider>().enabled = false;
        Debug.Log("Moving player");

        Vector3 initial_position = player.transform.position;
        Vector3 final_position = player.transform.position + direction;
        Debug.Log("Player final position should be " + final_position);

        /* Transition to new "room" */
        yield return StartCoroutine(
            CoroutineUtilities.MoveObjectOverTime(player.transform, initial_position, final_position, 0.5f)
        );

        // Wait for camera to finish moving to the new room
        yield return new WaitForSeconds(1.9f);

        Debug.Log("Moving player again");
        initial_position = player.transform.position;
        final_position = player.transform.position + direction;
        Debug.Log("Player final position should be " + final_position);

        /* Transition to new "room" */
        yield return StartCoroutine(
            CoroutineUtilities.MoveObjectOverTime(player.transform, initial_position, final_position, 0.5f)
        );

        // Wait for player to finish moving
        yield return new WaitForSeconds(0.2f);
        player_anim.speed = 0.0f;
        yield return new WaitForSeconds(0.3f);

        player.GetComponent<BoxCollider>().enabled = true;
        player_control.enabled = true;
    }

    void setPrevTransition(string direction)
    {
        prevTransition = direction;
    }

    string getPrevTransition()
    {
        return prevTransition;
    }
}
