using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomTransition : MonoBehaviour
{
    Camera cam;
    GameObject player;
    Image filter;
    PlayerMovement player_control;
    Animator player_anim;
    readonly Vector3 cameraNorth = new Vector3(0, 11, 0);
    readonly Vector3 cameraEast = new Vector3(16, 0, 0);
    readonly Vector3 cameraSouth = new Vector3(0, -11, 0);
    readonly Vector3 cameraWest = new Vector3(-16, 0, 0);
    readonly Vector3 cameraDown = new Vector3(2,0,12);
    readonly Vector3 cameraUp = new Vector3(-2,0,-12);

    readonly Vector3 playerNorth = new Vector3(0, 1.5f, 0);
    readonly Vector3 playerEast = new Vector3(1.5f, 0, 0);
    readonly Vector3 playerSouth = new Vector3(0, -1.5f, 0);
    readonly Vector3 playerWest = new Vector3(-1.5f, 0, 0);
    readonly Vector3 playerDown = new Vector3(21, 65, 12);
    readonly Vector3 playerUp = new Vector3(21,60,0);


    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        player = GameObject.Find("Player");
        filter = GameObject.Find("BlackFilter").GetComponent<Image>();

        if (player != null)
        {
            player_control = player.GetComponent<PlayerMovement>();
            player_anim = player.GetComponent<Animator>();
        }

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
                    StartCoroutine(PlayerRoomTransition(playerNorth));
                    StartCoroutine(CameraRoomTransition(cameraNorth));
                }
                else if (this.CompareTag("EastDoor"))
                {
                    StartCoroutine(PlayerRoomTransition(playerEast));
                    StartCoroutine(CameraRoomTransition(cameraEast));
                }
                else if (this.CompareTag("SouthDoor"))
                {
                    StartCoroutine(PlayerRoomTransition(playerSouth));
                    StartCoroutine(CameraRoomTransition(cameraSouth));
                }
                else if (this.CompareTag("WestDoor"))
                {
                    StartCoroutine(PlayerRoomTransition(playerWest));
                    StartCoroutine(CameraRoomTransition(cameraWest));
                }
                else if (this.CompareTag("UpDoor"))
                {
                    StartCoroutine(CameraTurnBlack());
                    StartCoroutine(CoroutineUtilities.MoveObjectOverTime(player.transform, player.transform.position, playerUp, 0.4f));
                    StartCoroutine(CameraRoomTransition(cameraUp));
                    cam.orthographicSize=7.5f;
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
            CoroutineUtilities.MoveObjectOverTime(player.transform, initial_position, final_position, 0.4f)
        );

        // Wait for camera to finish moving to the new room
        yield return new WaitForSeconds(1.9f);

        Debug.Log("Moving player again");
        initial_position = player.transform.position;
        final_position = player.transform.position + direction;
        Debug.Log("Player final position should be " + final_position);

        /* Transition to new "room" */
        yield return StartCoroutine(
            CoroutineUtilities.MoveObjectOverTime(player.transform, initial_position, final_position, 0.4f)
        );

        // Wait for player to finish moving
        yield return new WaitForSeconds(0.2f);
        player_anim.speed = 0.0f;
        yield return new WaitForSeconds(0.2f);

        player.GetComponent<BoxCollider>().enabled = true;
        player_control.enabled = true;
    }

    IEnumerator CameraTurnBlack()
    {
        filter.color=new Color(0,0,0,255);
        yield return new WaitForSeconds(1f);
        filter.color=new Color(0,0,0,0);
    }
}
