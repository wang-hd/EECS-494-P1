using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFlyingMovement : EnemyMovement
{
    public bool moving = false;
    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        StartCoroutine(SpeedUpThenSlowDownAndStop());
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
        if (Vector2.Distance(transform.position, waypoint) <= 0.1)
        {
            SetNewDestination();
        }
    }

    public override void SetNewDestination()
    {
        float horizontal_offset = Random.Range(CoroutineUtilities.room_x_lower_bound, CoroutineUtilities.room_x_upper_bound);
        float vertical_offset = Random.Range(CoroutineUtilities.room_y_lower_bound, CoroutineUtilities.room_y_upper_bound);
        waypoint = new Vector2(init_camera_pos.x + horizontal_offset, init_camera_pos.y + vertical_offset);
    }

    IEnumerator SpeedUpThenSlowDownAndStop()
    {
        while (true)
        {
            moving = true;
            speed = 1f;
            yield return new WaitForSeconds(0.5f);
            speed = 2f;
            yield return new WaitForSeconds(0.75f);
            speed = 3f;
            yield return new WaitForSeconds(1f);
            speed = 4f;
            yield return new WaitForSeconds(1.5f);
            speed = 5f;
            yield return new WaitForSeconds(1.5f);
            speed = 4f;
            yield return new WaitForSeconds(1f);
            speed = 3f;
            yield return new WaitForSeconds(0.75f);
            speed = 2f;
            yield return new WaitForSeconds(0.5f);
            speed = 1f;
            yield return new WaitForSeconds(0.25f);
            moving = false;
            speed = 0f;
            yield return new WaitForSeconds(2.5f);
        }
    }
}
