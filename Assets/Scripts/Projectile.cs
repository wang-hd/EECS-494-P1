using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public int direction;

    // Start is called before the first frame update
    void Start()
    {
        direction = PlayerMovement.direction;
        GetComponent<Animator>().SetInteger("direction", direction);
        GetComponent<Animator>().SetBool("is_attack", true);
    }

    // Update is called once per frame
    void Update()
    {
        // Move
        Move();
    }

    void Move()
    {
        switch(direction) {
            case 0:
                transform.Translate(0, 0.1f, 0);
                break;
            case 1:
                transform.Translate(0.1f, 0, 0);
                break;
            case 2:
                transform.Translate(0, -0.1f, 0);
                break;
            case 3:
                transform.Translate(-0.1f, 0, 0);
                break;
        }
    }
}
