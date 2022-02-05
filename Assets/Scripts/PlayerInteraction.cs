using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerInteraction : HitInteraction
{
    public AudioClip enemy_attack_sound_clip;
    public AudioClip game_over_sound_clip;
    PlayerMovement player_control;
    HasHealth health;
    Animator animator;
    AudioSource audioSource;
    static bool is_invincible = false;

    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        player_control = GetComponent<PlayerMovement>();
        health = GetComponent<HasHealth>();
        animator = GetComponent<Animator>();
        audioSource = Camera.main.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        is_invincible = Inventory.god_mode;
    }

    public void getHit(GameObject enemy)
    {
        if (!is_invincible && enemy.GetComponent<EnemyAttack>() != null && Time.time > last_hit + 0.4f)
        {
            last_hit = Time.time;
            health.lose_health(enemy.GetComponent<EnemyAttack>().damage);
            if (health.is_dead())
            {
                StartCoroutine(resetGame());
                return;
            }
            StartCoroutine(HitInteraction(enemy));
        }
    }

    IEnumerator resetGame()
    {
        player_control.enabled = false;
        rb.velocity = Vector3.zero;
        audioSource.Stop();
        AudioSource.PlayClipAtPoint(game_over_sound_clip, Camera.main.transform.position);

        animator.SetFloat("horizontal_input", 0f);
        animator.SetFloat("vertical_input", 0f);
        animator.speed = 1f;
        animator.SetTrigger("die");

        GameObject[] enemies = GameObject.FindGameObjectsWithTag("enemy");
        foreach (GameObject enemy in enemies)
        {
            enemy.GetComponent<SpriteRenderer>().enabled = false;
            enemy.GetComponent<BoxCollider>().enabled = false;
        }

        yield return new WaitForSeconds(3.0f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        player_control.enabled = true;
    }

    IEnumerator HitInteraction(GameObject enemy)
    {
        player_control.enabled = false;
        Physics.IgnoreLayerCollision(6, 7, true);

        base.hit_stun(enemy);
        AudioSource.PlayClipAtPoint(enemy_attack_sound_clip, Camera.main.transform.position);

        yield return new WaitForSeconds(0.25f);

        GetComponent<Rigidbody>().velocity = Vector3.zero;
        player_control.enabled = true;
        Physics.IgnoreLayerCollision(6, 7, false);
    }

    public static void setPlayerInvincible(bool value)
    {
        is_invincible = value;
    }
}
