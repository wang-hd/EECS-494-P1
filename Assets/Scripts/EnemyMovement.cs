using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyMovement : MonoBehaviour
{
    // TODO TODO: REFACTOR THIS
    public float speed = 2f;
    public Vector2 waypoint;
    public Vector3 init_camera_pos;
    public LayerMask enemyAndPlayerLayer;
    protected Rigidbody rb;
    Animator animator;

    // Start is called before the first frame update
    public virtual void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        init_camera_pos = Camera.main.transform.position;
        SetNewDestination();
    }

    // Update is called once per frame
    public virtual void Update()
    {
        if (CoroutineUtilities.InCurrentRoom(transform.position, init_camera_pos))
        {
            animator.speed = 1;
            MoveTowardsDestination();
        }
        else
        {
            if (rb != null)
            {
                rb.velocity = Vector3.zero;
            }
            animator.speed = 0;
        }
    }

    public virtual void OnDisable()
    {
        if (rb != null)
        {
            rb.velocity = Vector3.zero;
        }
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
