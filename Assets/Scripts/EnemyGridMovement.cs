using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGridMovement : EnemyMovement
{
    Vector2[] directions = {Vector2.up, Vector2.right, Vector2.down, Vector2.left};

    public override void SetNewDestination()
    {
        Vector2 new_direction = directions[Random.Range(0, 4)];
        RaycastHit hit;
        Ray detect = new Ray (transform.position, new_direction);
        int move_distance =  0;
        if (Physics.Raycast(detect, out hit))
        {
            move_distance = Random.Range(0, Mathf.FloorToInt(hit.distance));
            //Debug.Log("distance = " + move_distance);
        }
        
        waypoint = new Vector2(transform.position.x, transform.position.y) + new_direction * move_distance;
        //Debug.Log(waypoint.ToString());
    } 
}
