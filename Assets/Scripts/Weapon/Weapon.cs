using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// TODO: This class represents all types of weapon
public class Weapon : MonoBehaviour
{
    bool is_attack = false;
    int direction_weapon = 0;

    private IEnumerator coroutine;

    //TODO: This function needs to be modified by each weapon
    public virtual void attack(int direction,float horizontal,float vertical){
    }

    void Update(){
        if(is_attack){
            // swords' transform move along the direction
            switch(direction_weapon){
                case 0:
                transform.Translate(0,0.1f,0);
                break;
                case 1:
                transform.Translate(0.1f,0,0);
                break;
                case 2:
                transform.Translate(0,-0.1f,0);
                break;
                case 3:
                transform.Translate(-0.1f,0,0);
                break;
                default:
                break;
            }
            
        }
    }

    // TODO: This function is common for all weapons, when this function is used, the weapon move along the direction to the edge of screen
    // ATTENTION: This design may have problems since the arrow could fly out of the room and collide with the enemies in other room
    public void swapIn(int direction, float horizontal,float vertical){
        //build a corotine
        coroutine = WaitAndPrint(2.0f);
        StartCoroutine(coroutine);
        direction_weapon = direction;
        is_attack = true;
        //set the weapon's animation to the correct direction
        GetComponent<Animator>().SetInteger("direction",direction);
        GetComponent<Animator>().SetBool("is_attack",true);
        transform.position = new Vector3(horizontal,vertical,0);
    }

    private IEnumerator WaitAndPrint(float waitTime){
        yield return new WaitForSeconds(waitTime);
        GetComponent<Animator>().SetBool("is_attack",false);
        is_attack = false;
    }

    //TODO: destroy or give every object a certain hurt when it collide with the enemy
    private void OnTriggerEnter(Collider other) {
        //if other's tag is enemy)
        if(other.CompareTag("enemy"))
        {
           other.gameObject.GetComponent<EnemyController>().get_hurt(1.0f);
        }
    }

}
