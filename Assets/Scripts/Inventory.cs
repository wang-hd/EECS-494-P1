using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    int rupee_count = 0;
    int bomb_count = 0;
    public int keys = 0;
    public static bool god_mode = false;
    
    //TODO: This function is to toggle the God mode
    void Update() {
        if(Input.GetKeyDown(KeyCode.Keypad1)||Input.GetKeyDown(KeyCode.Alpha1)){
            god_mode = !god_mode;
        }
    }
    public void add_rupees(int num_rupees)
    {
        rupee_count += num_rupees;
    }
    public void add_bombs (int num_bombs)
    {
        bomb_count += num_bombs;
    }

    public int get_rupees()
    {
        if (god_mode) return 999;
        return rupee_count;
    }

    public int get_bombs()
    {
        if (god_mode) return 999;
        return bomb_count;
    }

    public void add_keys(int num_keys)
    {
        keys += num_keys;
    }

    public int get_keys()
    {
        if (god_mode) return 999;
        return keys;
    }
}
