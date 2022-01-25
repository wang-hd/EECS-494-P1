using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyMovement : MonoBehaviour
{
    // TODO TODO: REFACTOR THIS
    public float speed = 2f;
    public Vector2 waypoint;
    public Vector3 init_camera_pos;
    public LayerMask enemyLayer;
    protected Rigidbody rb;

    // Start is called before the first frame update
    public virtual void Start()
    {
        rb = GetComponent<Rigidbody>();
        init_camera_pos = Camera.main.transform.position;
        SetNewDestination();
    }

    // Update is called once per frame
    public virtual void Update()
    {
        if (CoroutineUtilities.InCurrentRoom(transform, init_camera_pos))
        {
            MoveTowardsDestination();
        }
        else
        {
            rb.velocity = Vector3.zero;
        }
    }

    public virtual void OnDisable()
    {
        rb.velocity = Vector3.zero;
    }

    public virtual void MoveTowardsDestination()
    {
        // something
    }

    public virtual void SetNewDestination()
    {
        // something
    } 
}
