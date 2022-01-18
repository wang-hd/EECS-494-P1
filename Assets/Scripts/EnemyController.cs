using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private float attack = 1f;
    private float hit_force = 50f;
    public float speed = 2f;
    Vector2[] directions = {Vector2.up, Vector2.right, Vector2.down, Vector2.left};

    Vector2 waypoint;
    private HasHealth health;

    // Start is called before the first frame update
    void Start()
    {
        SetNewDestination();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, waypoint, speed*Time.deltaTime);
        if (Vector2.Distance(transform.position, waypoint) == 0)
        {
            SetNewDestination();
        }
    }
    private void OnCollisionEnter(Collision other) {
        GameObject object_collide_with = other.gameObject;
        
    }
    public float Get_attack()
    {
        return attack;
    }
    public float Get_force()
    {
        return hit_force;
    }

    private void SetNewDestination()
    {
        Vector2 new_direction = directions[Random.Range(0, 4)];
        RaycastHit hit;
        Ray detect = new Ray (transform.position, new_direction);
        int move_distance =  0;
        if (Physics.Raycast(detect, out hit))
        {
            move_distance = Random.Range(0, Mathf.FloorToInt(hit.distance));
            Debug.Log("distance = " + move_distance);
        }
        
        waypoint = new Vector2(transform.position.x, transform.position.y) + new_direction * move_distance;
        Debug.Log(waypoint.ToString());

    }

    public Vector2 GetNewDestination()
    {
        return waypoint;
    }

    
}
