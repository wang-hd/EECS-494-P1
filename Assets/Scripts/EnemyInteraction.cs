using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInteraction : MonoBehaviour
{
    public AudioClip enemy_death_sound;
    HasHealth enemy_health;
    EnemyMovement enemy_movement;
    HitInteraction enemy_interaction;
    bool is_invincible = false;

    // Start is called before the first frame update
    void Start()
    {
        enemy_health = GetComponent<HasHealth>();
        enemy_movement = GetComponent<EnemyMovement>();
        enemy_interaction = GetComponent<HitInteraction>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void getHit(GameObject player, float damage)
    {
        if (!is_invincible)
        {
            enemy_health.lose_health(damage);
            if (enemy_health.is_dead())
            {
                AudioSource.PlayClipAtPoint(enemy_death_sound, Camera.main.transform.position);
                Destroy(gameObject);
                return;
            }
            StartCoroutine(HitInteraction(player));
        }
    }

    IEnumerator HitInteraction(GameObject player)
    {
        enemy_movement.enabled = false;
        is_invincible = true;

        enemy_interaction.hit_stun(player);
        yield return new WaitForSeconds(0.5f);

        is_invincible = false;
        enemy_movement.enabled = true;
    }
}
