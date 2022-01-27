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
        StartCoroutine(SpeedControl());
        speed = 0f;
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
            SetNewDestination();
        }
    }

    public override void SetNewDestination()
    {
        float horizontal_offset = Random.Range(CoroutineUtilities.room_x_lower_bound, CoroutineUtilities.room_x_upper_bound);
        float vertical_offset = Random.Range(CoroutineUtilities.room_y_lower_bound, CoroutineUtilities.room_y_upper_bound);
        waypoint = new Vector2(init_camera_pos.x + horizontal_offset, init_camera_pos.y + vertical_offset);
    }

    IEnumerator SpeedControl()
    {
        while (true)
        {
            moving = true;
            speed = 0.5f;
            yield return new WaitForSeconds(0.25f);
            int maxSpeed = Random.Range(2, 6);
            for (int i = 0; i < maxSpeed; i++)
            {
                SpeedUp();
                yield return new WaitForSeconds(Random.Range(0.5f, 1f));
            }
            yield return new WaitForSeconds(1f);
            for (int i = 0; i < maxSpeed; i++)
            {
                SlowDown();
                yield return new WaitForSeconds(Random.Range(0.5f, 1f));
            }

            speed = 0.5f;
            yield return new WaitForSeconds(0.25f);
            speed = 0f;
            moving = false;
            yield return new WaitForSeconds(Random.Range(1.25f, 1.5f));
        }
    }

    void SpeedUp()
    {
        speed += 1f;
    }

    void SlowDown()
    {
        speed -= 1f;
    }
}
