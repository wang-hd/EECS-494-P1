using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator PlayerRoomTransition(Vector3 direction)
    {
        ArrowKeyMovement.player_control = false;
        Debug.Log("Moving player");

        Vector3 initial_position = transform.position;
        Vector3 final_position = transform.position + direction;
        Debug.Log("Player final position should be " + final_position);

        /* Transition to new "room" */
        yield return StartCoroutine(
            CoroutineUtilities.MoveObjectOverTime(transform, initial_position, final_position, 0.6f)
        );

        // Wait for camera to finish moving
        yield return new WaitForSeconds(2);

        Debug.Log("Moving player again");
        initial_position = transform.position;
        final_position = transform.position + direction;
        Debug.Log("Player final position should be " + final_position);

        /* Transition to new "room" */
        yield return StartCoroutine(
            CoroutineUtilities.MoveObjectOverTime(transform, initial_position, final_position, 0.6f)
        );

        ArrowKeyMovement.player_control = true;
    }
}
