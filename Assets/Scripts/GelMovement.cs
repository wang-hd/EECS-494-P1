using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GelMovement : EnemyGridMovement
{
    public override void MoveTowardsDestination()
    {
        Vector3 waypoint_pos = new Vector3(waypoint.x, waypoint.y, 0);
        transform.Translate(GetDirection(base.direction) * Time.deltaTime);
        if (Vector3.Distance(transform.position, waypoint_pos) <= 0.05)
        {
            transform.position = waypoint_pos;
            StartCoroutine(PauseThenNewDestination(Random.Range(0.1f, 0.7f)));
        }
    }

    public override void SetNewDestination()
    {
        Vector2 new_direction = Vector2.zero;
        int move_distance = 0;
        RaycastHit hit;
        do
        {
            new_direction = base.directions[Random.Range(0, 4)];
            Ray detect = new Ray(transform.position, new_direction);
            if (Physics.Raycast(detect, out hit, 100f, ~enemyAndPlayerLayer))
            {
                move_distance = Random.Range(1, Mathf.FloorToInt(hit.distance));
                if (move_distance > 2) move_distance = 2;
            }
        } while (hit.distance < 1);
        
        waypoint = new Vector2(Mathf.RoundToInt(transform.position.x), Mathf.RoundToInt(transform.position.y)) + new_direction * move_distance;
        base.SetCurrentDirection(new_direction);
    }

    IEnumerator PauseThenNewDestination(float time)
    {
        enabled = false;
        yield return new WaitForSeconds(time);
        enabled = true;
        SetNewDestination();
    }

    Vector3 GetDirection(int direction)
    {
        switch (direction)
        {
            case 0:
                return Vector3.up;
            case 1:
                return Vector3.right;
            case 2:
                return Vector3.down;
            case 3:
                return Vector3.left;
        }
        return Vector3.zero;
    }
}
