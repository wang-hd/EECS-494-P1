using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponControl : MonoBehaviour
//This class controls all of the weapon inventory, when to create weapon and when to destroy them
{
    public Weapon weapon_a;
    public Weapon weapon_b;

    public GameObject prefab_1;//This prefab stores swords
    public GameObject prefab_0;//This prefab stores bows

    public void createNewWeapon(string weapon_name, bool weapon_type){
        //INPUT: string - weapon name; bool - which weapon will be substitute
        //TODO: This function creates new weapon according to the input and destroy the origin weapon if they are not null
        if(weapon_type){
            if(weapon_a!=null){
                Destroy(weapon_a);  
            }
            switch(weapon_name){
                case "sword":
                weapon_a = Instantiate(prefab_1, new Vector3(0, -12, 0), Quaternion.identity).GetComponent<Weapon>();
                break;
                case "bow":
                weapon_a = Instantiate(prefab_0, new Vector3(0, -12, 0), Quaternion.identity).GetComponent<Weapon>();
                break;
                default:
                break;
                }
        }else{
            if(weapon_b!=null){
                Destroy(weapon_b);  
            }
            switch(weapon_name){
                case "sword":
                weapon_b = Instantiate(prefab_1, new Vector3(0, -12, 0), Quaternion.identity).GetComponent<Weapon>();
                break;
                case "bow":
                weapon_b = Instantiate(prefab_0, new Vector3(0, -12, 0), Quaternion.identity).GetComponent<Weapon>();
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
            return weapon_b.name;
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
            if(weapon_b!=null){
                weapon_b.attack(direction,horizontal,vertical);
            }else{
                Debug.Log("[WeaponControl.attack] There is no weapon B in Inventory");
            }
        }
    }

}
