using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private float attack = 0.5f;
    private float hit_force = 50f;
    private HasHealth health;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision other) {
        GameObject object_collide_with = other.gameObject;
        
    }
    public float get_attack()
    {
        return attack;
    }

    public float get_force()
    {
        return hit_force;
    }

    //TODO: This function is used when enemy get heart
    //TODO: Thereofore, for normal swords, the hurt is 1, and for higher level weapon, the hurt could be 2.
    public void get_hurt(float n){
        health = GetComponent<HasHealth>();
        if (health != null){
            health.lose_health(1.5f*n);
            Debug.Log($"[EnemyController.Gethurt] Current Health is {health.get_health()}");
        }else{
            Debug.Log("[EnemyController.Gethurt] uhhhh, health couldn't be found....");
        }
    }
    
}
