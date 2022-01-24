using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float Movement_speed = 4;
    public static int direction;
    Rigidbody rb;
    Inventory player_inventory;
    PlayerAttack player_attack;
    HasHealth player_health;
    Animator animator;
    readonly int up = 0;
    readonly int right = 1;
    readonly int down = 2;
    readonly int left = 3;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        player_inventory = GetComponent<Inventory>();
        player_attack = GetComponent<PlayerAttack>();
        player_health = GetComponent<HasHealth>();
        animator = GetComponent<Animator>();
        direction = up;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X) && !animator.GetBool("is_attack")) // placeholder
        {
            if (player_health.is_full_health())
            {
                // Spawn full health sword projectile
                player_attack.attack(direction, "sword");
            }
            // Attack with melee sword always
            StartCoroutine(SetAttacking(1));
        }
        else if (Input.GetKeyDown(KeyCode.Z) && !animator.GetBool("is_attack")) // placeholder
        {
            if (player_inventory.get_secondary_weapon() != null)
            {
                Debug.Log(player_inventory.get_secondary_weapon().name);
                player_attack.attack(direction, player_inventory.get_secondary_weapon().name);
                StartCoroutine(SetAttacking(2));
            }
        }
        else
        {
            Vector2 current_input = GetMovementInput();
            rb.velocity = current_input * Movement_speed;
            SetAnimationAndDirection(current_input.x, current_input.y);
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
            SetDirection(horizontal, vertical);
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

    private void SetDirection(float horizontal, float vertical) {
        if (vertical > 0)
        {
            direction = up;
        }
        else if (horizontal > 0)
        {
            direction = right;
        }
        else if (vertical < 0)
        {
            direction = down;
        }
        else if (horizontal < 0)
        {
            direction = left;
        }
        // If the player is not moving, keep previous direction
    }
}
