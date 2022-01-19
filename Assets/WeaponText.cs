using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponText : MonoBehaviour
{
    public WeaponControl weapon_controller;
    Text text_content;
    GameObject weapon;
    
    void Start()
    {
        text_content=GetComponent<Text>();
    }

    // TODO: This function updates the name of weapon and shows it on the screen
    void Update()
    {
        if(weapon_controller!=null&&text_content!=null){
            text_content.text="weapon_1 is: "+weapon_controller.returnNameA()+"\r\n";
        }
        if(weapon_controller!=null&&text_content!=null){
            text_content.text+="weapon_2 is: "+weapon_controller.returnNameB();
        }
    }
}
