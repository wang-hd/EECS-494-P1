using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float attack = 0.5f;
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
        if (object_collide_with.CompareTag("weapon"))
        {
            health -= 1;
        }
        else if (object_collide_with.CompareTag("player"))
        {

        }
    }
    public float Get_attack()
    {
        return attack;
    }

    
}
