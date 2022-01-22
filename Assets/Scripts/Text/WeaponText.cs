using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponText : MonoBehaviour
{
    Inventory inventory;
    Text text_content;
    GameObject weapon;
    
    void Start()
    {
        text_content = GetComponent<Text>();
        inventory = GameObject.Find("Player").GetComponent<Inventory>();
    }

    // TODO: This function updates the name of weapon and shows it on the screen
    void Update()
    {
        // if (weapon_controller!=null && text_content!=null && this.CompareTag("weapon"))
        // {
        //     text_content.text = weapon_controller.returnNameA();
        // }
        if (inventory != null && text_content != null && this.CompareTag("weapon_b") && inventory.get_secondary_weapon() != null)
        {
            text_content.text = inventory.get_secondary_weapon().name;
        }
    }
}
