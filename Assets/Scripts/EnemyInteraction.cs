using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInteraction : MonoBehaviour
{
    public AudioClip enemy_death_sound;
    Rigidbody enemy_rb;
    HasHealth enemy_health;
    EnemyMovement enemy_movement;
    float hit_force = 5f;
    float attack = 1f;
    bool is_invincible = false;

    // Start is called before the first frame update
    void Start()
    {
        enemy_rb = GetComponent<Rigidbody>();
        enemy_health = GetComponent<HasHealth>();
        enemy_movement = GetComponent<EnemyMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (enemy_health.is_dead())
        {
            AudioSource.PlayClipAtPoint(enemy_death_sound, Camera.main.transform.position);
            Destroy(gameObject);
        }
    }

    public float get_attack()
    {
        return attack;
    }

    public void getHit(GameObject player)
    {
        if (!is_invincible)
        {
            enemy_health.lose_health(1f);
            StartCoroutine(HitInteraction(player));
        }
    }

    IEnumerator HitInteraction(GameObject player)
    {
        enemy_movement.enabled = false;
        is_invincible = true;

        enemy_health.hit_stun(enemy_rb, player, hit_force);
        yield return new WaitForSeconds(0.5f);

        is_invincible = false;
        enemy_movement.enabled = true;
    }
}
