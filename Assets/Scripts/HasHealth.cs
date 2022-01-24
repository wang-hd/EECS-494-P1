using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HasHealth : MonoBehaviour
{
    public float max_health = 6.0f;
    float curr_health;

    void Start()
    {
        curr_health = max_health;
    }

    public void add_health (float num_health)
    {
        curr_health += num_health;
        if (curr_health >= max_health)
        {
            curr_health = max_health;
        }
    }

    public void lose_health (float num_health)
    {
        curr_health -= num_health;
    }

    public float get_health()
    {
        return curr_health;
    }

    public bool is_full_health()
    {
        return curr_health >= max_health;
    }
    
    public bool is_dead()
    {
        return curr_health <= 0f;
    }

    public void hit_stun(Rigidbody self, GameObject enemy, float hit_force)
    {
        self.AddForce(Vector3.Normalize(returnDirection(enemy)) * (-hit_force), ForceMode.Impulse);
        // Debug.Log("add force" + Vector3.Normalize(returnDirection(enemy)).ToString());
    }

    private Vector2 returnDirection( GameObject ObjectHit )
    {    
        RaycastHit MyRayHit;
        Vector3 direction = ( transform.position - ObjectHit.transform.position ).normalized;
        Ray MyRay = new Ray( ObjectHit.transform.position, direction );
        
        if ( Physics.Raycast( MyRay, out MyRayHit ) ){
                
            if ( MyRayHit.collider != null ){
                
                Vector3 MyNormal = MyRayHit.normal;
                MyNormal = MyRayHit.transform.TransformDirection( MyNormal );
                
                if( MyNormal == MyRayHit.transform.up ){ return new Vector2(0, 1); }
                if( MyNormal == -MyRayHit.transform.up ){ return new Vector2(0, -1); }
                if( MyNormal == MyRayHit.transform.right ){ return new Vector2(1, 0); }
                if( MyNormal == -MyRayHit.transform.right ){ return new Vector2(-1, 0); }
            }    
        }
        return Vector2.zero;
    }
}
