using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponText : MonoBehaviour
{
    Inventory inventory;
    //Text text_content;
    GameObject weapon;
    Image weapon_a;
    Image bow;
    Image boomerang;
    Image bomb;

    void Start()
    {
        //text_content = GetComponent<Text>();
        inventory = GameObject.Find("Player").GetComponent<Inventory>();

        weapon_a = GameObject.Find("Weapon_A").GetComponent<Image>();
        bow = GameObject.Find("BowImage").GetComponent<Image>();
        boomerang = GameObject.Find("BoomerangImage").GetComponent<Image>();
        bomb = GameObject.Find("BombImage").GetComponent<Image>();

        if (PlayerMovement.isCustomLevel) weapon_a.enabled = false;
        else weapon_a.enabled = true;
        bow.enabled = false;
        boomerang.enabled = false;
        bomb.enabled = false;
    }

    // TODO: This function updates the name of weapon and shows it on the screen
    void Update()
    {
        if (PlayerMovement.isCustomLevel && PlayerMovement.getLeaf) weapon_a.enabled = true;
        //if (inventory != null && text_content != null && this.CompareTag("weapon_b") && inventory.get_secondary_weapon() != null)
        if (inventory != null && this.CompareTag("weapon_b") && inventory.get_secondary_weapon() != null)
        {
            string weaponName = inventory.get_secondary_weapon().name;
            if (weaponName == "arrow")
            {
                bow.enabled = true;
                boomerang.enabled = false;
                bomb.enabled = false;
            }
            else if (weaponName == "boomerang")
            {
                bow.enabled = false;
                boomerang.enabled = true;
                bomb.enabled = false;
            }
            else if (weaponName == "Bomb")
            {
                bow.enabled = false;
                boomerang.enabled = false;
                bomb.enabled = true;
            }
        }
    }
}
