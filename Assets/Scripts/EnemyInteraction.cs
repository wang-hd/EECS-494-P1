using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInteraction : HitInteraction
{
    public AudioClip enemy_death_sound;
    public bool ignore_hit = false;
    HasHealth health;
    EnemyMovement movement;
    public float stun_duration = 0f;
    float max_duration = 3f;

    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        health = GetComponent<HasHealth>();
        movement = GetComponent<EnemyMovement>();
        StartCoroutine(StunInteraction());
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

    public void stun(float time)
    {
        if (movement != null)
        {
            stun_duration += time;
            if (stun_duration > max_duration) stun_duration = max_duration;
        }
    }

    IEnumerator EnemyDeath()
    {
        AudioSource.PlayClipAtPoint(enemy_death_sound, Camera.main.transform.position);
        Destroy(gameObject);
        yield return null;
    }

    IEnumerator HitInteraction(GameObject player)
    {
        if (!ignore_hit) movement.enabled = false;

        base.hit_stun(player);
        yield return new WaitForSeconds(0.5f);

        if (!ignore_hit) movement.enabled = true;
        if (!ignore_hit) movement.SetNewDestination();
    }

    IEnumerator StunInteraction()
    {
        while (true)
        {
            while (stun_duration > 0)
            {
                movement.enabled = false;
                yield return new WaitForSeconds(1f);
                stun_duration--;
                movement.enabled = true;
            }
            yield return null;
        }
    }
}
