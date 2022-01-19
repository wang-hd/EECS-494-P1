using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HasHealth : MonoBehaviour
{
    private float curr_health = 3.0f;
    private float max_health = 3.0f;

    public bool God_Mode;
    
    void Start()
    {
        
    }

    //TODO: This function is to change the player into god mode;
    public void God_health(){
        curr_health = 100000000f;
        max_health = curr_health;
    }

    public void Add_health (float num_health)
    {
        curr_health += num_health;
        if (curr_health >= max_health)
        {
            curr_health = max_health;
        }
    }
    public void Lose_health (float num_health)
    {
        curr_health -= num_health;
    }

    public float Get_health()
    {
        return curr_health;
    }

    public bool Is_full_health()
    {
        return curr_health >= max_health;
    }
    
    public bool Is_dead()
    {
        return curr_health <= 0f;
    }
}
