using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    // TODO TODO: REFACTOR THIS
    public float speed = 2f;
    Vector3 init_camera_pos;
    protected Vector2 waypoint;

    // Start is called before the first frame update
    void Start()
    {
        init_camera_pos = Camera.main.transform.position;
        SetNewDestination();
    }

    // Update is called once per frame
    void Update()
    {
        if (CoroutineUtilities.InCurrentRoom(transform, init_camera_pos))
        {
            MoveTowardsDestination();
        }
    }

    public virtual void MoveTowardsDestination()
    {
        transform.position = Vector2.MoveTowards(transform.position, waypoint, speed*Time.deltaTime);
        if (Vector2.Distance(transform.position, waypoint) == 0)
        {
            SetNewDestination();
        }
    }

    public virtual void SetNewDestination()
    {
        // something
    } 
}
