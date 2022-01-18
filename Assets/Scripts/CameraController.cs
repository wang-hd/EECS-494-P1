using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public IEnumerator CameraRoomTransition(Vector3 direction)
    {
        // Wait for player to finish moving into the doorway
        yield return new WaitForSeconds(0.75f);

        Debug.Log("Moving camera");
        Vector3 initial_position = transform.position;
        Vector3 final_position = transform.position + direction;

        /* Transition to new "room" */
        yield return StartCoroutine(
            CoroutineUtilities.MoveObjectOverTime(transform, initial_position, final_position, 1.75f)
        );
    }
}
