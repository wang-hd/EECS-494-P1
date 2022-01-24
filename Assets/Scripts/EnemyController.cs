using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    // TODO TODO: REFACTOR THIS
    private float attack = 1f;
    private float hit_force = 25f;
    public float speed = 2f;
    public AudioClip enemy_death_sound;
    HasHealth health;
    Vector2[] directions = {Vector2.up, Vector2.right, Vector2.down, Vector2.left};
    Vector2 waypoint;
    Vector3 init_camera_pos;

    // Start is called before the first frame update
    void Start()
    {
        health = GetComponent<HasHealth>();
        init_camera_pos = Camera.main.transform.position;
        SetNewDestination();
    }

    // Update is called once per frame
    void Update()
    {
        if (health.is_dead())
        {
            AudioSource.PlayClipAtPoint(enemy_death_sound, Camera.main.transform.position);
            Destroy(gameObject);
        }

        if (CoroutineUtilities.InCurrentRoom(transform, init_camera_pos))
        {
            // movement is enabled
            transform.position = Vector2.MoveTowards(transform.position, waypoint, speed*Time.deltaTime);
            if (Vector2.Distance(transform.position, waypoint) == 0)
            {
                SetNewDestination();
            }
        }
    }
    private void OnCollisionEnter(Collision other) {
        GameObject object_collide_with = other.gameObject;
        
    }
    public float get_attack()
    {
        return attack;
    }

    public float get_force()
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

    //TODO: This function is used when enemy get heart
    //TODO: Thereofore, for normal swords, the hurt is 1, and for higher level weapon, the hurt could be 2.
    public void get_hurt(float n){
        if(health != null){
            health.lose_health(n);
            Debug.Log($"[EnemyController.Gethurt] Current Health is {health.get_health()}");
        }else{
            Debug.Log("[EnemyController.Gethurt] uhhhh, health couldn't be found....");
        }
    }
    
}
