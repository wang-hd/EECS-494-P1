using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public int rupee_count = 0;
    public int keys = 0;
    public void Add_rupees (int num_rupees)
    {
        rupee_count += num_rupees;
    }

    public int Get_rupees()
    {
        return rupee_count;
    }
}
