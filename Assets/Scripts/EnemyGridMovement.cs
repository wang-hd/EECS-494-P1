using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGridMovement : EnemyMovement
{
    public int direction;
    GridBasedMovement grid;
    Vector2[] directions = {Vector2.up, Vector2.right, Vector2.down, Vector2.left};

    public override void Start()
    {
        base.Start();
        grid = GetComponent<GridBasedMovement>();
    }

    public override void Update()
    {
        base.Update();
        grid.AdjustPosition(direction);
    }

    public override void MoveTowardsDestination()
    {
        // transform.position = Vector2.MoveTowards(transform.position, waypoint, speed*Time.deltaTime);
        if ((direction == GridBasedMovement.up || direction == GridBasedMovement.down) && transform.position.x != waypoint.x)
        {
            SetNewDestination();
        }
        else if ((direction == GridBasedMovement.right || direction == GridBasedMovement.left) && transform.position.y != waypoint.y)
        {
            SetNewDestination();
        }
        else
        {
            Vector2 current_pos = new Vector2(transform.position.x, transform.position.y);
            base.rb.velocity = (waypoint - current_pos).normalized * speed;
            if (Vector2.Distance(transform.position, waypoint) <= 0.01)
            {
                Debug.Log("reached destination!");
                SetNewDestination();
                Debug.Log("new waypoint: " + waypoint);
            }
        }
    }

    public override void SetNewDestination()
    {
        Vector2 new_direction = directions[Random.Range(0, 4)];
        RaycastHit hit;
        Ray detect = new Ray(transform.position, new_direction);
        int move_distance =  0;
        if (Physics.Raycast(detect, out hit, 100f, ~enemyAndPlayerLayer))
        {
            move_distance = Random.Range(0, Mathf.FloorToInt(hit.distance));
            //Debug.Log("distance = " + move_distance);
        }
        
        waypoint = new Vector2(Mathf.RoundToInt(transform.position.x), Mathf.RoundToInt(transform.position.y)) + new_direction * move_distance;
        SetCurrentDirection(new_direction);
        //Debug.Log(waypoint.ToString());
    }

    private void SetCurrentDirection(Vector2 new_direction) {
        if (new_direction == Vector2.up)
        {
            direction = GridBasedMovement.up;
        }
        else if (new_direction == Vector2.right)
        {
            direction = GridBasedMovement.right;
        }
        else if (new_direction == Vector2.down)
        {
            direction = GridBasedMovement.down;
        }
        else if (new_direction == Vector2.left)
        {
            direction = GridBasedMovement.left;
        }
    }
}
