using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public IEnumerator PlayerRoomTransition(Vector3 direction)
    {
        ArrowKeyMovement.player_control = false;
        // GetComponent<BoxCollider>().enabled = false;
        Debug.Log("Moving player");

        Vector3 initial_position = transform.position;
        Vector3 final_position = transform.position + direction;
        Debug.Log("Player final position should be " + final_position);

        /* Transition to new "room" */
        yield return StartCoroutine(
            CoroutineUtilities.MoveObjectOverTime(transform, initial_position, final_position, 0.5f)
        );

        // Wait for camera to finish moving to the new room
        yield return new WaitForSeconds(2);

        Debug.Log("Moving player again");
        initial_position = transform.position;
        final_position = transform.position + direction;
        Debug.Log("Player final position should be " + final_position);

        /* Transition to new "room" */
        yield return StartCoroutine(
            CoroutineUtilities.MoveObjectOverTime(transform, initial_position, final_position, 0.5f)
        );

        // Wait for player to finish moving
        yield return new WaitForSeconds(0.5f);

        // GetComponent<BoxCollider>().enabled = true;
        ArrowKeyMovement.player_control = true;
    }
}
