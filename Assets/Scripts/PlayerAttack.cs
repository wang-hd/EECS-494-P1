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
    PlayerMovement playerMovement;
    int melee_damage = 1;

    void Start()
    {
        inventory = GetComponent<Inventory>();
        playerMovement = GetComponent<PlayerMovement>();

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
                if (is_full_health&&sword_projectiles <= 1)
                {
                    result = Instantiate(sword_prefab, player_pos, Quaternion.identity);
                    result.GetComponent<Swords>().setProjectile();
                    return result;
                }else if(!is_full_health)
                {
                    switch(PlayerMovement.direction)
                    {
                        case 0:
                            player_pos=player_pos+Vector3.up*0.5f;
                            break;
                        case 1:
                            player_pos=player_pos+Vector3.right*0.5f;
                            break;
                        case 2:
                            player_pos=player_pos+Vector3.down*0.5f;
                            break;
                        case 3:
                            player_pos=player_pos+Vector3.left*0.5f;
                            break;
                        default:
                            break;
                    }
                    return Instantiate(sword_prefab, player_pos, Quaternion.identity);
                }
                break;
            case "bow":
                if (bow_projectiles <= 1 && inventory != null && inventory.get_rupees() > 0)
                {
                    inventory.add_rupees(-1);
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
}
