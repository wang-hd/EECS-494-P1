using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    int rupee_count = 0;
    float player_health = 3.0f;
    float max_player_health = 3.0f;

    public void Add_health (float num_health)
    {
        player_health += num_health;
        if (player_health >= max_player_health)
        {
            player_health = max_player_health;
        }
    }
    public void Lose_health (float num_health)
    {
        player_health -= num_health;
    }
    public void Add_rupees (int num_rupees)
    {
        rupee_count += num_rupees;
    }

    public float Get_health()
    {
        return player_health;
    }
    public int Get_rupees()
    {
        return rupee_count;
    }
}
