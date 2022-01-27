using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boomerang : Weapon
{
    // Start is called before the first frame update
    bool is_fly_out=true;
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
        if (is_fly_out&&!CoroutineUtilities.InCurrentRoom(transform, init_camera_pos))
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
                    rb.velocity = new Vector3(0,3f,0);
                    break;
                case 1:
                    rb.velocity = new Vector3(3f,0,0);
                    break;
                case 2:
                    rb.velocity = new Vector3(0,-3f,0);
                    break;
                case 3:
                    rb.velocity = new Vector3(-3f,0,0);
                    break;
            }
        }else
        {
            rb.velocity = (GameObject.Find("Player").transform.position-transform.position).normalized*3f;
        }
    }
    public override void OnTriggerEnter(Collider other)
    {
        //if other's tag is enemy
        if (other.CompareTag("enemy"))
        {
            other.gameObject.GetComponent<EnemyInteraction>().getHit(GameObject.Find("Player"), damage);
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
