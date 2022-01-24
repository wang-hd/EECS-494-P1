using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// TODO: This class represents all types of weapon
public class Weapon : MonoBehaviour
{
    public static float weapon_force = 5f;
    // TODO: destroy or give every object a certain hurt when it collide with the enemy
    public virtual void OnTriggerEnter(Collider other) {
        //if other's tag is enemy
        if (other.CompareTag("enemy"))
        {
           other.gameObject.GetComponent<EnemyInteraction>().getHit(GameObject.Find("Player"));
        }
    }
}
