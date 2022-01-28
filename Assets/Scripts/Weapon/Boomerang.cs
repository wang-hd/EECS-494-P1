using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boomerang : Weapon
{
    // Start is called before the first frame update
    public float speed = 8f;
    bool is_fly_out = true;
    int direction;
    Vector3 init_camera_pos;
    Rigidbody rb;

    void Start()
    {
        direction = PlayerMovement.direction;
        init_camera_pos = Camera.main.transform.position;
        rb = GetComponent<Rigidbody>();
        boomerang_move();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0,0,10);
        boomerang_move();
        if (is_fly_out&&!CoroutineUtilities.InCurrentRoom(transform.position, init_camera_pos))
        {
            is_fly_out=false;
        }
    }

    void boomerang_move()
    {
        if(is_fly_out)
        {
            switch(direction) {
                case 0:
                    rb.velocity = new Vector3(0,speed,0);
                    break;
                case 1:
                    rb.velocity = new Vector3(speed,0,0);
                    break;
                case 2:
                    rb.velocity = new Vector3(0,-speed,0);
                    break;
                case 3:
                    rb.velocity = new Vector3(-speed,0,0);
                    break;
            }
        }else
        {
            rb.velocity = (GameObject.Find("Player").transform.position-transform.position).normalized*speed;
        }
    }
    public override void OnTriggerEnter(Collider other)
    {
        //if other's tag is enemy
        if (other.CompareTag("enemy"))
        {
            HasHealth enemyHealth = other.gameObject.GetComponent<HasHealth>();
            if (enemyHealth != null && enemyHealth.max_health == 1)
            {
                enemyHealth.lose_health(1);
            }
            else
            {
                EnemyInteraction enemyInteraction = other.gameObject.GetComponent<EnemyInteraction>();
                if (enemyInteraction != null) enemyInteraction.stun();
            }

            if(is_fly_out)
            {
              is_fly_out=false;
            }
        }else if (other.CompareTag("player")&&!is_fly_out)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerStay(Collider other)
    {
        //if other's tag is enemy
        if (other.CompareTag("player")&&!is_fly_out&&gameObject!=null)
        {
            Destroy(gameObject);
        }
    }
}
