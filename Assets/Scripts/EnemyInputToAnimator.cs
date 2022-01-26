using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInputToAnimator : MonoBehaviour
{
    Animator animator;
    EnemyGridMovement grid_movement;
    EnemyFlyingMovement fly_movement;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        grid_movement = GetComponent<EnemyGridMovement>();
        fly_movement = GetComponent<EnemyFlyingMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (grid_movement != null)
        {
            animator.SetInteger("direction", grid_movement.direction);
        }
        else if (fly_movement != null)
        {
            if (!fly_movement.moving)
            {
                animator.speed = 0f;
            }
            else
            {
                animator.speed = fly_movement.speed / 3;
            }
        }
    }
}
