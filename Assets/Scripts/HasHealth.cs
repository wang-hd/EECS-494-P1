using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HasHealth : MonoBehaviour
{
    public float max_health = 6.0f;
    float curr_health;

    void Start()
    {
        curr_health = max_health;
    }

    public void add_health (float num_health)
    {
        curr_health += num_health;
        if (curr_health >= max_health)
        {
            curr_health = max_health;
        }
    }
    
    public void lose_health (float num_health)
    {
        curr_health -= num_health;
    }

    public float get_health()
    {
        return curr_health;
    }

    public bool is_full_health()
    {
        return curr_health >= max_health;
    }
    
    public bool is_dead()
    {
        return curr_health <= 0f;
    }
}
