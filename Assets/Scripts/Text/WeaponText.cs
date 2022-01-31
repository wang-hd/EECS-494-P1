using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponText : MonoBehaviour
{
    Inventory inventory;
    //Text text_content;
    GameObject weapon;
    GameObject bow;
    GameObject boomerang;
    GameObject bomb;

    void Start()
    {
        //text_content = GetComponent<Text>();
        inventory = GameObject.Find("Player").GetComponent<Inventory>();

        bow = GameObject.Find("BowImage");
        boomerang = GameObject.Find("BoomerangImage");
        bomb = GameObject.Find("BombImage");
    }

    // TODO: This function updates the name of weapon and shows it on the screen
    void Update()
    {
        //if (inventory != null && text_content != null && this.CompareTag("weapon_b") && inventory.get_secondary_weapon() != null)
        if (inventory != null && this.CompareTag("weapon_b") && inventory.get_secondary_weapon() != null)
        {
            string weaponName = inventory.get_secondary_weapon().name;
            if (weaponName == "bow")
            {
                bow.SetActive(true);
                boomerang.SetActive(false);
                bomb.SetActive(false);
            }
            else if (weaponName == "boomerang")
            {
                bow.SetActive(false);
                boomerang.SetActive(true);
                bomb.SetActive(false);
            }
            else if (weaponName == "Bomb")
            {
                bow.SetActive(false);
                boomerang.SetActive(false);
                bomb.SetActive(true);
            }
        }
    }
}
