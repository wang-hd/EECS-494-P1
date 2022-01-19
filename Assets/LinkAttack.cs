using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TODO: This class is to let Link attack the enemy.
public class LinkAttack : MonoBehaviour
{
    Animator player_animator;
    // Start is called before the first frame update
    void Start()
    {
        player_animator = GetComponent<Animator>();
    }

    //TODO: This detects whether player attacks the enemy, we need to set all of the enemy to the same layer
    void FixedUpdate()
    {
        int layerMask = 1<<8;
        layerMask = ~layerMask;
        RaycastHit hit;
        if(player_animator.tag=="attack"&&Physics.Raycast(transform.position,transform.forward,out hit, 1.0f, layerMask)){
            //here to make some hurt to hit.collider
        }
    }
}
