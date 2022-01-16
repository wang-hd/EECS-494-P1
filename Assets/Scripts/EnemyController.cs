using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private float attack = 0.5f;
    private float hit_force = 50f;
    private float health = 1.0f;
    // Start is called before the first frame update
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
    public float Get_attack()
    {
        return attack;
    }

    public float Get_force()
    {
        return hit_force;
    }

    
}
