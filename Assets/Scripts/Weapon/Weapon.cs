using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// TODO: This class is used by all types of weapon, but will be inherited by its subclass
public class Weapon : MonoBehaviour
{
    public float damage = 1f;

    // TODO: When every weapons are created, it will move with players
    // 1. it will get the player's direction and position by link the player to this
    // 2. it will change its direction and position according to the player
    // 3. direction should be sent to the animator
    void Update(){

    }

    // TODO: This function is used when the player is going to attack
    // 1. the weapon should be able to collide and it should be Visible
    // 2. then the remaining function would be implemented by the subclass
    public virtual void attack(){

    }

    public virtual void setProjectile(){
      
    }
    // TODO: destroy or give every object a certain hurt when it collide with the enemy
    public virtual void OnTriggerEnter(Collider other) {
        //if other's tag is enemy
        if (other.CompareTag("enemy"))
        {
           other.gameObject.GetComponent<EnemyInteraction>().getHit(GameObject.Find("Player"), damage);
        }
    }
}
