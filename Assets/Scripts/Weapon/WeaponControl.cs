using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponControl : MonoBehaviour
//This class controls all of the weapon inventory, when to create weapon and when to destroy them
{
    Weapon weapon_a;
    Weapon weapon_b;
    Inventory inventory;

    public GameObject sword_prefab; //This prefab stores swords

    void Start()
    {
        inventory = GetComponentInParent<Inventory>();
    }

    void Update()
    {

    }

    public void createNewWeapon(string weapon_name, bool weapon_type){
        //INPUT: string - weapon name; bool - which weapon will be substitute
        //TODO: This function creates new weapon according to the input
        // Will not create a weapon if a weapon already exists, to prevent double attacking
        if (weapon_type)
        {
            weapon_a = Instantiate(sword_prefab, new Vector3(0, -12, 0), Quaternion.identity).GetComponent<Weapon>();
        }
        else
        {
            switch(weapon_name)
            {
                case "bow":
                    weapon_b = Instantiate(inventory.get_secondary_weapon(), new Vector3(0, -12, 0), Quaternion.identity).GetComponent<Weapon>();
                    break;
            }
        }
    }

    public string returnNameA(){
        //TODO: This function returns the name of weapon A
        return "sword";
    }

    public string returnNameB(){
        //TODO: This function returns the name of weapon B
        if(inventory.get_secondary_weapon() != null) {
            return inventory.get_secondary_weapon().name;
        }else{
            return "[WeaponControl.returnNameB] no weapon B";
        }
    }

    public void attack(int direction, bool weapon_type,float horizontal, float vertical){
        //TODO: This function makes the character attack and if hull health, call shooting function
        // If weapon already exists, do not attack
        if(weapon_type) {
            if (weapon_a == null)
            {
                createNewWeapon("sword", true);
                weapon_a.attack(direction, horizontal, vertical);
            }
        }else{
            if (weapon_b == null)
            {
                createNewWeapon(inventory.get_secondary_weapon().name, false);
                Debug.Log(weapon_b);
                weapon_b.attack(direction, horizontal, vertical);
            }
            else
            {
                Debug.Log("[WeaponControl.attack] There is no weapon B in Inventory");
            }
        }
    }

}
