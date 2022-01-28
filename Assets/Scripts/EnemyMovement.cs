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
        MoveTowardsDestination();
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
        Vector2 current_pos = new Vector2(transform.position.x, transform.position.y);
        rb.velocity = (waypoint - current_pos).normalized * speed;
    }

    public virtual void SetNewDestination()
    {
        // something
    } 
}
