using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponControl : MonoBehaviour
//This class controls all of the weapon inventory, when to create weapon and when to destroy them
{
    public Weapon weapon_a;
    public List<Weapon> weapon_b;
    public int secondary_index = 0;
    public Inventory inventory;

    public GameObject prefab_1; //This prefab stores swords
    public GameObject prefab_0; //This prefab stores bows

    void Start()
    {
        inventory = GetComponentInParent<Inventory>();
    }

    void Update()
    {
        if (Input.GetKeyDown("space") && weapon_b.Count > 1)
        {
            if (secondary_index == weapon_b.Count)
            {
                secondary_index = 0;
            }
            else
            {
                secondary_index += 1;
            }
        }
    }

    public void createNewWeapon(string weapon_name, bool weapon_type){
        //INPUT: string - weapon name; bool - which weapon will be substitute
        //TODO: This function creates new weapon according to the input and destroy the origin weapon if they are not null
        if(weapon_type)
        {
            if(weapon_a!=null){
                Destroy(weapon_a);  
            }
            switch(weapon_name){
                case "sword":
                weapon_a = Instantiate(prefab_1, new Vector3(0, -12, 0), Quaternion.identity).GetComponent<Weapon>();
                break;
            }
        }
        else
        {
            if(weapon_b!=null){
                Destroy(weapon_b[secondary_index]);  
            }
            switch(weapon_name){
                case "bow":
                weapon_b[secondary_index] = Instantiate(prefab_0, new Vector3(0, -12, 0), Quaternion.identity).GetComponent<Weapon>();
                break;
                default:
                break;
            }
        
        }
    }

    public string returnNameA(){
        //TODO: This function returns the name of weapon A
        if(weapon_a!=null){
            return weapon_a.name;
        }else{
            return "[WeaponControl.returnNameA] no weapon A";
        }
    }

    public string returnNameB(){
        //TODO: This function returns the name of weapon B
        if(weapon_b!=null){
            return weapon_b[secondary_index].name;
        }else{
            return "[WeaponControl.returnNameB] no weapon B";
        }
    }

    public void attack(int direction, bool weapon_type,float horizontal, float vertical){
        //TODO: This function makes the character attack and if hull health, call shooting function
        if(weapon_type){
            if(weapon_a!=null){
                weapon_a.attack(direction, horizontal, vertical);
            }else{
                Debug.Log("[WeaponControl.attack] There is no weapon A in Inventory");
            }
        }else{
            if(weapon_b!=null && inventory.get_rupees() > 0){
                weapon_b[secondary_index].attack(direction,horizontal,vertical);
                inventory.add_rupees(-1);
            }else{
                Debug.Log("[WeaponControl.attack] There is no weapon B in Inventory");
            }
        }
    }

}
