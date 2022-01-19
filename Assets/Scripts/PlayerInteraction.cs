using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerInteraction : MonoBehaviour
{
    ArrowKeyMovement player_control;
    HasHealth player_health;
    private Rigidbody player_rb;
    public AudioClip enemy_attack_sound_clip;
    public AudioClip game_over_sound_clip;
    public AudioSource audioSource;
    public Inventory player_invent;

    private bool game_over = false;
    private bool is_invincible = false;
    private SpriteRenderer player_sprite;
    private Color player_origin_color;

    // Start is called before the first frame update
    void Start()
    {
        player_control = GetComponent<ArrowKeyMovement>();
        player_health = GetComponent<HasHealth>(); 
        player_rb = GetComponent<Rigidbody>(); 
        player_sprite = GetComponent<SpriteRenderer>();
        player_origin_color = player_sprite.color;
    }

    // Update is called once per frame
    void Update()
    {
        if (game_over == true)
        {
            
            if (Input.GetKeyDown(KeyCode.Return))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                player_control.SetPlayerControl(true);
            }
        }

        is_invincible = Inventory.god_mode;
    }

    private void OnCollisionEnter(Collision other) {
        GameObject object_collider_with = other.gameObject;
        if (object_collider_with.CompareTag("enemy"))
        {
            EnemyController enemy = object_collider_with.GetComponent<EnemyController>();

            if (!is_invincible)
            {
                hit_stun(object_collider_with, enemy.get_force());
                player_health.lose_health(enemy.get_attack());
                if (player_health.is_dead())
                {
                    game_over = true;
                    ArrowKeyMovement.player_control = false;
                    audioSource.Stop();
                    AudioSource.PlayClipAtPoint(game_over_sound_clip, Camera.main.transform.position);
                    player_control.SetPlayerControl(false);
                    return;
                }
                StartCoroutine(become_invincible());
                AudioSource.PlayClipAtPoint (enemy_attack_sound_clip, Camera.main.transform.position);
                StartCoroutine(change_color());
            }
        }
    }
    IEnumerator change_color()
    {
        Color player_origin_color = player_sprite.color;
        player_sprite.color = new Color(1, 0, 0, 1);
        yield return new WaitForSeconds(0.1f);
        player_sprite.color = player_origin_color;
    }

    IEnumerator become_invincible()
    {
        is_invincible = true;
        yield return new WaitForSeconds(0.8f);
        is_invincible  = false;
    }

    private void hit_stun(GameObject enemy, float hit_force)
    {
        player_rb.AddForce(Vector3.Normalize(returnDirection(enemy)) * (-hit_force), ForceMode.Impulse);
        Debug.Log("add force" + Vector3.Normalize(returnDirection(enemy)).ToString());
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
