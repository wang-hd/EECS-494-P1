using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitInteraction : MonoBehaviour
{
    public float hit_force = 100f;
    public Rigidbody rb;
    public SpriteRenderer sprite;
    public float last_hit = 0;
    Vector2[] directions = {Vector2.up, Vector2.right, Vector2.down, Vector2.left};

    public virtual void Start()
    {
        rb = GetComponent<Rigidbody>();
        sprite = GetComponent<SpriteRenderer>();
    }

    public void hit_stun(GameObject enemy)
    {
        if (rb != null && hit_force > 0)
        {
            rb.velocity = Vector3.zero;
            rb.AddForce(Vector3.Normalize(returnDirection(enemy)) * (-hit_force), ForceMode.Impulse);
            // Debug.Log("add force" + Vector3.Normalize(returnDirection(enemy)).ToString());
        }
        if (sprite != null)
        {
            StartCoroutine(change_color(sprite));
        }
    }

    public void hit_stun_no_change(GameObject enemy)
    {
        if (rb != null && hit_force > 0)
        {
            rb.velocity = Vector3.zero;
            rb.AddForce(Vector3.Normalize(returnDirection(enemy)) * (-hit_force), ForceMode.Impulse);
        }
    }

    private Vector2 returnDirection( GameObject ObjectHit )
    {
        int direction = 0;
        if (gameObject.CompareTag("player"))
        {
            direction = PlayerMovement.direction;
        }
        else if (gameObject.CompareTag("enemy"))
        {
            EnemyGridMovement enemyMovement = gameObject.GetComponent<EnemyGridMovement>();
            //direction = enemyMovement.direction;
             
            RaycastHit MyRayHit;
            Vector3 MyDirection = ( transform.position - ObjectHit.transform.position ).normalized;
            Ray MyRay = new Ray( ObjectHit.transform.position, MyDirection );
            
            if ( Physics.Raycast( MyRay, out MyRayHit ) ){
                    
                if ( MyRayHit.collider != null ){
                    
                    Vector3 MyNormal = MyRayHit.normal;
                    MyNormal = MyRayHit.transform.TransformDirection( MyNormal );
                    
                    if( MyNormal == MyRayHit.transform.up ){ direction = 0; }
                    if( MyNormal == -MyRayHit.transform.up ){ direction = 2; }
                    if( MyNormal == MyRayHit.transform.right ){ direction = 1; }
                    if( MyNormal == -MyRayHit.transform.right ){ direction = 3; }
                }    
            }
        }

        return directions[direction];
    }

    /*
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
    */

    public IEnumerator change_color(SpriteRenderer sprite)
    {
        Color origin_color = sprite.color;
        sprite.color = new Color(1, 0, 0, 1);
        yield return new WaitForSeconds(0.1f);
        sprite.color = origin_color;
    }
}
