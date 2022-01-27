using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInputToAnimator : MonoBehaviour
{
    public Animator animator;
    EnemyGridMovement grid_movement;
    EnemyFlyingMovement fly_movement;
    HasHealth health;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        grid_movement = GetComponent<EnemyGridMovement>();
        fly_movement = GetComponent<EnemyFlyingMovement>();
        health = GetComponent<HasHealth>();
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
                animator.SetFloat("animator_speed", 0f);
            }
            else
            {
                animator.SetFloat("animator_speed", 1f);
            }
        }

        if (health.is_dead())
        {
            animator.SetTrigger("dead"); // TODO: add enemy death animation
        }
    }
}
