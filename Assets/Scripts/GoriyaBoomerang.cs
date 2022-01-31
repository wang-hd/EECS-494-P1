using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoriyaBoomerang : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 8f;
    public float max_distance = 5f;
    bool is_fly_out = true;
    int direction;
    Vector3 init_position;
    Vector3 init_camera_pos;
    Rigidbody rb;
    GameObject goriya;

    void Start()
    {
        init_camera_pos = Camera.main.transform.position;
        rb = GetComponent<Rigidbody>();
        boomerang_move();
    }

    // Update is called once per frame
    void Update()
    {
        if (goriya == null)
        {
            Destroy(gameObject);
        }
        
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
            if (Vector3.Distance(transform.position, goriya.transform.position) <= 0.05)
            {
                goriya.GetComponent<GoriyaAttack>().returned = true;
                Destroy(gameObject);
            } 
        }
    }

    public void SetParentGoriya(GameObject parentGoriya)
    {
        goriya = parentGoriya;
        init_position = parentGoriya.transform.position;
        direction = parentGoriya.GetComponent<EnemyGridMovement>().direction;
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
            rb.velocity = (goriya.transform.position-transform.position).normalized*speed;
        }
    }
    void OnTriggerEnter(Collider other)
    {
        //if other's tag is enemy
        if (other.CompareTag("player"))
        {
            other.gameObject.GetComponent<PlayerInteraction>().getHit(goriya);

            if (is_fly_out)
            {
              is_fly_out = false;
            }
        }
    }
}
