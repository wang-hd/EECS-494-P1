using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boomerang : Weapon
{
    // Start is called before the first frame update
    public float speed = 8f;
    public float max_distance = 5f;

    bool is_fly_out = true;
    int direction;
    Vector3 init_position;
    Vector3 init_camera_pos;
    Rigidbody rb;
    GameObject player;
    float stun_duration = 3f;

    void Start()
    {
        direction = PlayerMovement.direction;
        init_camera_pos = Camera.main.transform.position;
        rb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
        init_position = player.transform.position;
        PlayerAttack.boomerang_projectiles++;

        boomerang_move();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0,0,10);
        boomerang_move();
        if (is_fly_out)
        {
            if (!CoroutineUtilities.InCurrentRoom(transform.position, init_camera_pos) || Vector3.Distance(init_position, transform.position) > max_distance)
            {
                is_fly_out = false;
            }
        }
        else
        {
            if (Vector3.Distance(transform.position, player.transform.position) <= 0.05) Destroy(gameObject);
        }
    }

    void OnDestroy()
    {
        PlayerAttack.boomerang_projectiles--;
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
            rb.velocity = (player.transform.position-transform.position).normalized*speed;
        }
    }
    public override void OnTriggerEnter(Collider other)
    {
        //if other's tag is enemy
        if (other.CompareTag("enemy"))
        {
            HasHealth enemyHealth = other.gameObject.GetComponent<HasHealth>();
            EnemyInteraction enemyInteraction = other.gameObject.GetComponent<EnemyInteraction>();
            if (enemyHealth != null && enemyHealth.max_health == 1)
            {
                if (enemyInteraction != null) enemyInteraction.getHit(player, damage);
            }
            else
            {
                if (enemyInteraction != null) enemyInteraction.stun(stun_duration);
            }

            if (is_fly_out)
            {
              is_fly_out=false;
            }
        }
    }
}
