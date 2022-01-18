using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    int rupee_count = 0;
    int bomb_count = 0;

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
}
