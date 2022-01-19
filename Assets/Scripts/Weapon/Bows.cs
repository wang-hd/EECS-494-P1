using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TODO: This is for the bow 
public class Bows : Weapon
{
    public Animator player_animator;

    string name = "bow";

    int number = 2;

    private IEnumerator coroutine;

    //TODO: if player has full health, then call the shooting function of weapon;
    public override void attack(int direction, float horizontal,float vertical){
        coroutine = WaitAndPrint(0.2f);
        StartCoroutine(coroutine);

        player_animator.SetInteger("no_of_weapon", number);
        player_animator.SetBool("is_attack", true);
        base.swapIn(direction, horizontal, vertical);
    }

    private IEnumerator WaitAndPrint(float waitTime){
        yield return new WaitForSeconds(waitTime);
        player_animator.SetBool("is_attack", false);
    }
}
