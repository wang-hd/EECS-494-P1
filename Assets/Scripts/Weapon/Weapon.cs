using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// TODO: This class is used by all types of weapon, but will be inherited by its subclass
public class Weapon : MonoBehaviour
{
    public int damage = 1;

    public virtual void setProjectile(){

    }
    // TODO: destroy or give every object a certain hurt when it collide with the enemy
    public virtual void OnTriggerEnter(Collider other) {
        //if other's tag is enemy
        if (other.CompareTag("enemy"))
        {
           other.gameObject.GetComponent<EnemyInteraction>().getHit(GameObject.Find("Player"), damage);
        }
        else if (other.CompareTag("projectilehit"))
        {
            other.gameObject.GetComponentInParent<EnemyInteraction>().getHit(GameObject.Find("Player"), damage);
        }
    }
}
