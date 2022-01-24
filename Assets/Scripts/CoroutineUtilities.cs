using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoroutineUtilities
{
    public static IEnumerator MoveObjectOverTime(Transform target, Vector3 initial_pos, Vector3 dest_pos, float duration_sec)
    {
        float initial_time = Time.time;
        // The "progress" variable will go from 0.0f -> 1.0f over the course of "duration_sec" seconds.
        float progress = (Time.time - initial_time) / duration_sec;

        while(progress < 1.0f)
        {
            // Recalculate the progress variable every frame. Use it to determine
            // new position on line from "initial_pos" to "dest_pos"
            progress = (Time.time - initial_time) / duration_sec;
            Vector3 new_position = Vector3.Lerp(initial_pos, dest_pos, progress);
            target.position = new_position;

            // yield until the end of the frame, allowing other code / coroutines to run
            // and allowing time to pass.
            yield return null;
        }

        target.position = dest_pos;
    }

    public static bool InCurrentRoom(Transform transform, Vector3 camera_pos)
    {
        if (transform.position.x > camera_pos.x + 6.5)
        {
            return false;
        }
        else if (transform.position.x < camera_pos.x - 6.5)
        {
            return false;
        }
        else if (transform.position.y > camera_pos.y + 2)
        {
            return false;
        }
        else if (transform.position.y < camera_pos.y - 6)
        {
            return false;
        }
        else if (Camera.main.transform.position != camera_pos)
        {
            return false;
        }
        return true;
    }
}
