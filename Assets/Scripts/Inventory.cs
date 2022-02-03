using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    int rupees  = 0;
    int bombs = 0;
    int keys = 0;
    public bool bomb_acquired = false;
    public List<GameObject> weapons; // Only for secondary weapons. Link always has the sword
    int secondary_index = 0;
    public GameObject sword_prefab; // This prefab stores swords
    public GameObject bow_prefab; // Stores arrow prefab (not bow)
    public GameObject boomerang_prefab;
    public GameObject bomb_prefab;

    public static bool god_mode = false;

    void Start()
    {
        
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Keypad1) || Input.GetKeyDown(KeyCode.Alpha1))
        {
            god_mode = !god_mode;
        }

        if (Input.GetKeyDown("space") && weapons.Count > 1)
        {
            secondary_index += 1;
            if (secondary_index == weapons.Count)
            {
                secondary_index = 0;
            }
        }
    }

    public void add_rupees(int num_rupees)
    {
        rupees += num_rupees;
    }

    public void add_bombs(int num_bombs)
    {
        bombs += num_bombs;
    }

    public int get_rupees()
    {
        if (god_mode) return 999;
        return rupees;
    }

    public int get_bombs()
    {
        if (god_mode) return 999;
        return bombs;
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

    public GameObject get_secondary_weapon()
    {
        if (weapons.Count == 0) return null;
        return weapons[secondary_index];
    }

    public void add_bow()
    {
        weapons.Add(bow_prefab);
    }

    public void add_boomerang()
    {
        weapons.Add(boomerang_prefab);
    }

    public void add_bomb_weapon()
    {
        weapons.Add(bomb_prefab);
    }
}
