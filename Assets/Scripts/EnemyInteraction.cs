using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInteraction : HitInteraction
{
    public AudioClip enemy_death_sound;
    HasHealth health;
    EnemyMovement movement;

    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        health = GetComponent<HasHealth>();
        movement = GetComponent<EnemyMovement>();
    }

    public void getHit(GameObject player, int damage)
    {
        if (health != null && Time.time > last_hit + 0.5f)
        {
            last_hit = Time.time;
            health.lose_health(damage);
            if (health.is_dead())
            {
                StartCoroutine(EnemyDeath());
                return;
            }
            StartCoroutine(HitInteraction(player));
        }
    }

    public void stun()
    {
        if (movement != null) StartCoroutine(StunInteraction());
    }

    IEnumerator EnemyDeath()
    {
        AudioSource.PlayClipAtPoint(enemy_death_sound, Camera.main.transform.position);
        Destroy(gameObject);
        yield return null;
    }

    IEnumerator HitInteraction(GameObject player)
    {
        movement.enabled = false;

        base.hit_stun(player);
        yield return new WaitForSeconds(0.5f);

        movement.enabled = true;
    }

    IEnumerator StunInteraction()
    {
        movement.enabled = false;
        yield return new WaitForSeconds(3f);
        movement.enabled = true;
    }
}
