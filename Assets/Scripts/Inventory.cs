using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    int rupee_count = 0;
    int bomb_count = 0;
    public int keys = 0;
    public bool God_Mode = false;
    
    //TODO: This function is to open the God mode
    private void Update() {
        if(Input.GetKeyDown(KeyCode.Keypad1)||Input.GetKeyDown(KeyCode.Alpha1)){
            rupee_count=100000000;
            bomb_count = 100000000;
            keys = 100000000;
            God_Mode = true;
        }
    }
    public void Add_rupees (int num_rupees)
    {
        rupee_count += num_rupees;
    }
    public void Add_bombs (int num_bombs)
    {
        bomb_count += num_bombs;
    }

    public int Get_rupees()
    {
        return rupee_count;
    }

    public int Get_bombs()
    {
        return bomb_count;
    }

    public void add_keys(int num_keys)
    {
        keys += num_keys;
    }

    public int get_keys()
    {
        return keys;
    }
}
