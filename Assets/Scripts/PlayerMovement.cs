using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float Movement_speed = 4;
    public AudioClip sword_attack_sound_clip;
    public static int direction;
    public static bool isCustomLevel = false;
    public static bool getLeaf = false;
    GridBasedMovement grid;
    Rigidbody rb;
    Inventory player_inventory;
    PlayerAttack player_attack;
    HasHealth player_health;
    Animator animator;
    GameObject created_weapon;

    // Start is called before the first frame update
    void Start()
    {
        grid = GetComponent<GridBasedMovement>();
        rb = GetComponent<Rigidbody>();
        player_inventory = GetComponent<Inventory>();
        player_attack = GetComponent<PlayerAttack>();
        player_health = GetComponent<HasHealth>();
        animator = GetComponent<Animator>();
        direction = GridBasedMovement.up;

    }

    // Update is called once per frame
    void Update()
    {
        if (Inventory.god_mode) Movement_speed = 10f;
        else Movement_speed = 4f;

        if (!animator.GetBool("is_attack"))
        {
            if (Input.GetKeyDown(KeyCode.X) && CoroutineUtilities.InCurrentRoom(transform.position, Camera.main.transform.position))
            {
                if (isCustomLevel)
                {
                    if (getLeaf) Attack("leaf");
                    else return;
                }
                else Attack("sword");
                return;
            }
            else if (Input.GetKeyDown(KeyCode.Z) && CoroutineUtilities.InCurrentRoom(transform.position, Camera.main.transform.position))
            {
                if (player_inventory.get_secondary_weapon() != null)
                {
                    Debug.Log(player_inventory.get_secondary_weapon().name);
                    Attack(player_inventory.get_secondary_weapon().name);
                    return;
                }
            }

            // If not attacking, move around
            Vector2 current_input = GetMovementInput();
            rb.velocity = current_input * Movement_speed;
            SetAnimationAndDirection(current_input.x, current_input.y);
            grid.AdjustPosition(direction);
        }
    }

    Vector2 GetMovementInput()
    {
        float horizontal_input = Input.GetAxisRaw("Horizontal");
        float vertical_input = Input.GetAxisRaw("Vertical");
        if (!CoroutineUtilities.InCurrentRoom(transform.position, Camera.main.transform.position))
        {
            if (transform.position.x > Camera.main.transform.position.x + CoroutineUtilities.room_x_upper_bound)
            {
                if (vertical_input != 0) vertical_input = 0;
            }
            else if (transform.position.x < Camera.main.transform.position.x + CoroutineUtilities.room_x_lower_bound)
            {
                if (vertical_input != 0) vertical_input = 0;
            }
            else if (transform.position.y > Camera.main.transform.position.y + CoroutineUtilities.room_y_upper_bound)
            {
                if (horizontal_input != 0) horizontal_input = 0;
            }
            else if (transform.position.y < Camera.main.transform.position.y + CoroutineUtilities.room_y_lower_bound)
            {
                if (horizontal_input != 0) horizontal_input = 0;
            }
        }
        if (Mathf.Abs(horizontal_input) > 0.0f) {
            vertical_input = 0.0f;
        }

        return new Vector2(horizontal_input, vertical_input);
    }

    void Attack(string weapon_name)
    {
        switch(weapon_name)
        {
            case "sword":
              if (player_health.is_full_health() || Inventory.god_mode)
                {
                    // Spawn full health sword projectile
                    player_attack.createNewWeapon("sword");
                }
                // Attack with melee sword always
                AudioSource.PlayClipAtPoint (sword_attack_sound_clip, Camera.main.transform.position);
                player_attack.attack();
                // created_weapon = player_attack.createNewWeapon("sword");
                StartCoroutine(SetAttacking(2));
                break;
            case "leaf":
                player_attack.createNewWeapon("leaf");

                // Attack with melee sword always
                player_attack.attack();
                // created_weapon = player_attack.createNewWeapon("sword");
                StartCoroutine(SetAttacking(1));
                break;
            case "Bomb":
                created_weapon = player_attack.createNewWeapon("bomb");
                if(created_weapon!=null)
                {
                  created_weapon.GetComponent<Bombs>().Attack();
                }
                break;
            default:
                player_attack.createNewWeapon(weapon_name);
                StartCoroutine(SetAttacking(1));
                break;
        }

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
        rb.velocity = Vector3.zero;
        animator.SetInteger("no_of_weapon", number);
        animator.SetBool("is_attack", true);
        yield return new WaitForSeconds(0.25f);
        animator.SetBool("is_attack", false);
        if(created_weapon!=null)
        {
            Destroy(created_weapon);
        }
    }

    private void SetDirection(float horizontal, float vertical) {
        if (vertical > 0)
        {
            direction = GridBasedMovement.up;
        }
        else if (horizontal > 0)
        {
            direction = GridBasedMovement.right;
        }
        else if (vertical < 0)
        {
            direction = GridBasedMovement.down;
        }
        else if (horizontal < 0)
        {
            direction = GridBasedMovement.left;
        }
        // If the player is not moving, keep previous direction
    }
}
