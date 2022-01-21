using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float Movement_speed = 4;
    public static bool player_control = true;
    Rigidbody rb;
    WeaponControl weapon_control;
    HasHealth player_health;
    Animator animator;
    readonly int up = 0;
    readonly int right = 1;
    readonly int down = 2;
    readonly int left = 3;
    int direction;
    bool attacking = false; // In the future, will be set by the weapon projectiles to true when spawned and false when destroyed, to prevent multiple projectiles from being active at once.
    // This variable is distinct from the animator is_attack because that boolean only controls the animation, not player state. A player can still move around when a projectile is active, just not attack again.

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        weapon_control = GetComponentInChildren<WeaponControl>();
        player_health = GetComponent<HasHealth>();
        animator = GetComponent<Animator>();
        direction = up;
    }

    // Update is called once per frame
    void Update()
    {
        if (player_control)
        {
            if (Input.GetKeyDown(KeyCode.X) && !animator.GetBool("is_attack")) // placeholder
            {
                weapon_control.attack(direction, Input.GetKeyDown(KeyCode.X), transform.position.x, transform.position.y);
                StartCoroutine(SetAttacking(2));
            }
            else if (Input.GetKeyDown(KeyCode.Z) && !animator.GetBool("is_attack")) // placeholder
            {
                weapon_control.attack(direction, Input.GetKeyDown(KeyCode.X), transform.position.x, transform.position.y);
                // TODO - integrate with inventory to determine which secondary weapon Link is holding, and therefore what animation should play
            }
            else
            {
                Vector2 current_input = GetMovementInput();
                rb.velocity = current_input * Movement_speed;
                SetAnimationAndDirection(current_input.x, current_input.y);
            }
        }
    }

    Vector2 GetMovementInput() 
    {
        float horizontal_input = Input.GetAxisRaw("Horizontal");
        float vertical_input = Input.GetAxisRaw("Vertical");
        if (Mathf.Abs(horizontal_input) > 0.0f) {
            vertical_input = 0.0f;
        }

        return new Vector2(horizontal_input, vertical_input);
    }

    void SetAnimationAndDirection(float horizontal, float vertical)
    {
        animator.SetFloat("horizontal_input", horizontal);
        animator.SetFloat("vertical_input", vertical);

        if (horizontal == 0 && vertical == 0 && !(animator.GetBool("is_attack") || animator.GetCurrentAnimatorStateInfo(0).IsTag("attack")))
        {
            animator.speed = 0.0f;
        }
        else
        {
            direction = GetDirection(horizontal, vertical);
            animator.speed = 1.0f;
        }
    }

    IEnumerator SetAttacking(int number)
    {
        animator.SetInteger("no_of_weapon", number);
        animator.SetBool("is_attack", true);
        yield return new WaitForSeconds(0.2f);
        animator.SetBool("is_attack", false);
    }

    private int GetDirection(float horizontal, float vertical){
        if (vertical > 0)
        {
            return up;
        }
        else if (horizontal > 0)
        {
            return right;
        }
        else if (vertical < 0)
        {
            return down;
        }
        return left;
    }

    public void SetPlayerControl(bool value)
    {
        player_control = value;
    }

    public bool GetPlayerControl()
    {
        return player_control;
    }
}
