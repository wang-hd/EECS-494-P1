using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TODO: This is for the bow 
public class Bows : Weapon
{
    public Animator player_animator;
    Inventory inventory;
    string name = "bow";
    int number = 2;

    void Start()
    {
        inventory = GetComponentInParent<Inventory>();
        player_animator = GameObject.Find("Player").GetComponent<Animator>();
    }


    // Attack and consume a rupee as ammo. Do not attack if no rupees.
    public override void attack(int direction, float horizontal,float vertical)
    {
        if (inventory != null && inventory.get_rupees() > 0)
        {
            inventory.add_rupees(-1);
            base.swapIn(direction, horizontal, vertical);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);
        if (other.CompareTag("enemy"))
        {
            Destroy(gameObject);
        }
    }
}
