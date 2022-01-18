using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputToAnimator : MonoBehaviour
{
    Animator animator;
    public HasHealth player_health;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (ArrowKeyMovement.player_control)
        {
            animator.SetFloat("horizontal_input", Input.GetAxisRaw("Horizontal"));
            animator.SetFloat("vertical_input", Input.GetAxisRaw("Vertical"));

            if (Input.GetAxisRaw("Horizontal") == 0 && Input.GetAxisRaw("Vertical") == 0)
            {
                if (!animator.GetCurrentAnimatorStateInfo(0).IsTag("Attack"))
                {
                    animator.speed = 0.0f;
                }
            }
            else
            {
                animator.speed = 1.0f;
            }
            
            if (Input.GetKeyDown(KeyCode.X))
            {
                animator.ResetTrigger("attack");
                animator.SetTrigger("attack");
                animator.speed = 1f;
                Debug.Log(animator.GetCurrentAnimatorStateInfo(0).IsTag("Attack"));
                Debug.Log("Pressed X");
            }
        }
        if (player_health.Is_dead())
        {
            animator.SetFloat("horizontal_input", 0f);
            animator.SetFloat("vertical_input", 0f);
            animator.speed = 1f;
            animator.SetBool("is_dead", true);
        }
    }
}
