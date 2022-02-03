using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AquamentusMovement : EnemyMovement
{
    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
    }

    public override void MoveTowardsDestination()
    {
        Vector2 current_pos = new Vector2(transform.position.x, transform.position.y);
        base.rb.velocity = (waypoint - current_pos).normalized * speed;
        if (Vector2.Distance(transform.position, waypoint) <= 0.05)
        {
            transform.position = waypoint;
            SetNewDestination();
        }
    }

    public override void SetNewDestination()
    {
        float horizontal_offset = 0f;
        do
        {
            horizontal_offset = Random.Range(-5, 5);
        } while ((transform.position.x + horizontal_offset > init_camera_pos.x + 5f) || (transform.position.x + horizontal_offset < init_camera_pos.x + 1.5f));
        waypoint = new Vector2(transform.position.x + horizontal_offset, transform.position.y);
    }
}
