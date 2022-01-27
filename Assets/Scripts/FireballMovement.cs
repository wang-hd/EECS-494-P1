using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballMovement : EnemyMovement
{
    public static int fireballs = 0;
    int fireball_num;
    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        fireballs++;
        fireball_num = fireballs;
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
        if (!CoroutineUtilities.InCurrentRoom(transform.position, init_camera_pos) && fireball_num > 1)
        {
            fireballs--;
            Destroy(gameObject);
        }
    }

    public void SetDestination(Vector3 player_pos, int offset)
    {
        waypoint = new Vector2(init_camera_pos.x + CoroutineUtilities.room_x_lower_bound, player_pos.y + offset * 2.1f);
        if (offset != 0) speed += 0.05f;
    }

    public override void MoveTowardsDestination()
    {
        base.MoveTowardsDestination();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("player"))
        {
            Destroy(gameObject);
        }
    }
}
