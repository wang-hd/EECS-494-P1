using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerInteraction : MonoBehaviour
{
    Inventory inventory;
    private Rigidbody player_rb;
    public AudioClip enemy_attack_sound_clip;
    public AudioClip game_over_sound_clip;
    private bool game_over = false;
    private SpriteRenderer player_sprite;
    private Color player_origin_color;

    // Start is called before the first frame update
    void Start()
    {
        inventory = GetComponent<Inventory>(); 
        player_rb = GetComponent<Rigidbody>(); 
        player_sprite = GetComponent<SpriteRenderer>();
        player_origin_color = player_sprite.color;
    }

    // Update is called once per frame
    void Update()
    {
        if (game_over == true)
        {
            AudioSource.PlayClipAtPoint(game_over_sound_clip, Camera.main.transform.position);
            if (Input.GetKeyDown(KeyCode.Return))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }

    private void OnCollisionEnter(Collision other) {
        GameObject object_collider_with = other.gameObject;
        if (object_collider_with.CompareTag("enemy"))
        {
            EnemyController enemy = object_collider_with.GetComponent<EnemyController>();
            inventory.Lose_health(enemy.Get_attack());
            AudioSource.PlayClipAtPoint (enemy_attack_sound_clip, Camera.main.transform.position);
            Color player_origin_color = player_sprite.color;
            player_sprite.color = new Color(1, 0, 0, 1);
            StartCoroutine(Change_color());
            if (inventory.Get_health() <= 0.0f)
            {
                game_over = true;
            }
            Hit_stun(object_collider_with, enemy.Get_force());
        }
    }

    IEnumerator Change_color()
    {
        yield return new WaitForSeconds(0.1f);
        player_sprite.color = player_origin_color;
    }

    private void Hit_stun(GameObject enemy, float hit_force)
    {
        player_rb.AddForce(Vector3.Normalize(ReturnDirection(enemy)) * (-hit_force), ForceMode.Impulse);
        Debug.Log("add force" + Vector3.Normalize(ReturnDirection(enemy)).ToString());
    }

    private Vector2 ReturnDirection( GameObject ObjectHit )
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
