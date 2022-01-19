using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputToAnimator : MonoBehaviour
{
    public HasHealth player_health;
    public GameObject weapon_controll;

    int direction=0;
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (ArrowKeyMovement.player_control){
            animator.SetFloat("horizontal_input", Input.GetAxisRaw("Horizontal"));
            animator.SetFloat("vertical_input", Input.GetAxisRaw("Vertical"));

            if (Input.GetAxisRaw("Horizontal") == 0 && Input.GetAxisRaw("Vertical") == 0&&!(animator.GetBool("is_attack")||animator.GetCurrentAnimatorStateInfo(0).IsTag("attack")))
            {
                animator.speed = 0.0f;
            }
            else
            {
                animator.speed = 1.0f;
                direction=GetDirection(Input.GetAxisRaw("Horizontal"),Input.GetAxisRaw("Vertical"));
            }
    
            // To detect whether Link is attacking
            if (Input.GetKeyDown(KeyCode.J)||Input.GetKeyDown(KeyCode.K)){
                weapon_controll.GetComponent<WeaponControl>().attack(direction,Input.GetKeyDown(KeyCode.K),transform.position.x,transform.position.y);
            }

            if (player_health.Is_dead())
            {
                animator.speed = 1f;
                animator.SetBool("is_dead", true);
            }
        }
        
    }

    //TODO: This function is to generate the direction which will be parsed into the weapon component.
    private int GetDirection(float horizontal,float vertical){
        if(vertical>0){
            return 0;
        }else if(horizontal>0){
            return 1;
        }else if(vertical<0){
            return 2;
        }else if(horizontal<0){
            return 3;
        }
        return 4;
    }
}

