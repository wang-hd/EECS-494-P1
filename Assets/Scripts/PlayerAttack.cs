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
    public LayerMask enemyLayer;
    Inventory inventory;
    PlayerMovement playerMovement;
    int melee_damage = 1;

    void Start()
    {
        inventory = GetComponent<Inventory>();
        playerMovement = GetComponent<PlayerMovement>();
    }

    public GameObject createNewWeapon(string weapon_name){
        //INPUT: string - weapon name; bool - which weapon will be substitute
        //TODO: This function creates new weapon according to the input
        // Will not create a weapon if a weapon already exists, to prevent double attacking
        Vector3 player_pos = GameObject.Find("Player").transform.position;
        GameObject result;
        Vector3 player_dir = GetDirection(PlayerMovement.direction);
        Vector3 weapon_pos = player_pos + player_dir * 0.5f;
        switch(weapon_name)
        {
            case "sword":
                if (sword_projectiles <= 1)
                {
                    return Instantiate(sword_prefab, weapon_pos, Quaternion.identity);
                }
                break;
            case "arrow":
                if (bow_projectiles <= 1 && inventory != null && inventory.get_rupees() > 0)
                {
                    inventory.add_rupees(-1);
                    StartCoroutine(bowAnimation());
                    return Instantiate(bow_prefab, weapon_pos, Quaternion.identity);
                }
                break;
            case "boomerang":
                if (boomerang_projectiles <= 1)
                {
                    return Instantiate(boomerang_prefab, weapon_pos, Quaternion.identity);
                }
                break;
            case "bomb":
                if (inventory != null && inventory.get_bombs() > 0)
                {
                    inventory.add_bombs(-1);
                    return Instantiate(bomb_prefab, weapon_pos, Quaternion.identity);
                }
                break;
        }
        return null;
    }

    public void attack() {
        //TODO: This function performs a melee attack in the current direction the player is facing
        Vector3 attack_dir = GetDirection(PlayerMovement.direction);

        RaycastHit[] hits = Physics.BoxCastAll(transform.position, transform.localScale, attack_dir, Quaternion.identity, 0.5f, enemyLayer);
        foreach (RaycastHit hit in hits)
        {
            GameObject object_collided = hit.collider.gameObject;
            if (object_collided.CompareTag("enemy"))
            {
                Debug.Log("hit an enemy with melee");
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

    Vector3 GetDirection(int direction)
    {
        switch (direction)
        {
            case 0:
                return Vector3.up;
            case 1:
                return Vector3.right;
            case 2:
                return Vector3.down;
            case 3:
                return Vector3.left;
        }
        return Vector3.zero;
    }
}
