using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public GameObject sword_prefab; //This prefab stores swords
    public GameObject bow_prefab;
    public GameObject boomerang_prefab;
    public GameObject bomb_prefab;
    public static int sword_projectiles = 0; // Ensures only one sword at a time
    public static int bow_projectiles = 0; // Only one arrow at a time
    public static int boomerang_projectiles = 0; // Only one (player) boomerang at a time
    Inventory inventory;
    float melee_damage = 1f;

    void Start()
    {
        inventory = GetComponent<Inventory>();
    }

    public GameObject createNewWeapon(string weapon_name, bool is_full_health){
        //INPUT: string - weapon name; bool - which weapon will be substitute
        //TODO: This function creates new weapon according to the input
        // Will not create a weapon if a weapon already exists, to prevent double attacking
        Vector3 player_pos = GameObject.Find("Player").transform.position;
        GameObject result;
        switch(weapon_name)
        {
            case "sword":
                if (sword_projectiles <= 1)
                {
                    result = Instantiate(sword_prefab, player_pos, Quaternion.identity);
                    result.GetComponent<Swords>().setProjectile();
                    return result;
                }
                break;
            case "bow":
                if (bow_projectiles <= 1 && inventory != null && inventory.get_rupees() > 0)
                {
                    inventory.add_rupees(-1);
                    StartCoroutine(bowAnimation());
                    return Instantiate(bow_prefab, transform.position, Quaternion.identity);
                }
                break;
            case "boomerang":
                if (boomerang_projectiles <= 1)
                {
                    return Instantiate(boomerang_prefab, transform.position, Quaternion.identity);
                }
                break;
            case "bomb":
                if (inventory != null && inventory.get_bombs() > 0)
                {
                    inventory.add_bombs(-1);
                    return Instantiate(bomb_prefab, transform.position, Quaternion.identity);
                }
                break;
        }
        return null;
    }

    public void attack() {
        //TODO: This function performs a melee attack in the current direction the player is facing
        Vector3 attack_dir = Vector3.zero;
        switch (PlayerMovement.direction)
        {
            case 0:
                attack_dir = Vector3.up;
                break;
            case 1:
                attack_dir = Vector3.right;
                break;
            case 2:
                attack_dir = Vector3.down;
                break;
            case 3:
                attack_dir = Vector3.left;
                break;
        }

        // TODO: This part could change by only the weapon touches,
        // TODO: In this part, create a new weapon and use the projectile function of that.
        RaycastHit[] hits = Physics.BoxCastAll(transform.position, transform.localScale, attack_dir, Quaternion.identity, 1f);
        foreach (RaycastHit hit in hits)
        {
            GameObject object_collided = hit.collider.gameObject;
            if (object_collided.CompareTag("enemy"))
            {
                if (object_collided.GetComponent<HasHealth>() != null)
                {
                    object_collided.GetComponent<EnemyInteraction>().getHit(gameObject, melee_damage);
                }
            }
        }
    }

    IEnumerator bowAnimation()
    {
        // TODO: spawn a bow sprite on top of the player
        yield return new WaitForSeconds(0.2f);
    }
}
