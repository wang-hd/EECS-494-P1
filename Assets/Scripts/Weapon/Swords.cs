using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// TODO: This class is an inheritance of weapon class, which is for swords.
public class Swords : Weapon
{
    public Animator player_animator;
    public HasHealth player_health;

    string name = "sword";
    int number = 1;

    //TODO: if player has full health, then call the shooting function of weapon;
    public override void attack(int direction, float horizontal,float vertical){
        StartCoroutine(WaitAndPrint(0.2f));

        player_animator.SetInteger("no_of_weapon", number);
        player_animator.SetBool("is_attack", true);
        
        // player has full health, call the shooting function from the base
        if (player_health.is_full_health())
        {
            base.swapIn(direction,horizontal,vertical);
        }
    }

    public override IEnumerator WaitAndPrint(float waitTime){
        yield return new WaitForSeconds(waitTime);
        player_animator.SetBool("is_attack", false);
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
