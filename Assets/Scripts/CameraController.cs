using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    public IEnumerator CameraRoomTransition(Vector3 direction)
    {
        Debug.Log("Moving camera");
        Vector3 initial_position = transform.position;
        Vector3 final_position = transform.position + direction;

        /* Transition to new "room" */
        yield return StartCoroutine(
            CoroutineUtilities.MoveObjectOverTime(transform, initial_position, final_position, 2.5f)
        );
    }
}
