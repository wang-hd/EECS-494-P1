using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    Inventory inventory;

    public GameObject sword_prefab; //This prefab stores swords
    public GameObject bow_prefab;
    public GameObject boomerang_prefab;
    public GameObject bomb_prefab;
    public static int sword_projectiles = 0; // Ensures only one sword at a time
    public static int bow_projectiles = 0; // Only one arrow at a time
    public static int boomerang_projectiles = 0; // Only one (player) boomerang at a time

    void Start()
    {
        inventory = GetComponent<Inventory>();
    }

    public GameObject createNewWeapon(string weapon_name){
        //INPUT: string - weapon name; bool - which weapon will be substitute
        //TODO: This function creates new weapon according to the input
        // Will not create a weapon if a weapon already exists, to prevent double attacking
        Vector3 player_pos = GameObject.Find("Player").transform.position;
        switch(weapon_name)
        {
            case "sword":
                if (sword_projectiles <= 1)
                {
                    Debug.Log("Initiating new sword projectile");
                    return Instantiate(sword_prefab, player_pos, Quaternion.identity);
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

    public void attack(int direction, string weapon_name) {
        //TODO: This function makes the character attack and if hull health, call shooting function
        // If weapon already exists, do not attack
        GameObject weapon = createNewWeapon(weapon_name);
        // Attack with the weapon, aka set projectile's desired position
        // weapon.attack(direction, horizontal, vertical);
    }

    IEnumerator bowAnimation()
    {
        // TODO: spawn a bow sprite on top of the player
        yield return new WaitForSeconds(0.2f);
    }
}
