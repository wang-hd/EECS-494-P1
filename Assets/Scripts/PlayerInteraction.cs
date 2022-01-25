using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerInteraction : MonoBehaviour
{
    public AudioClip enemy_attack_sound_clip;
    public AudioClip game_over_sound_clip;
    PlayerMovement player_control;
    HasHealth player_health;
    HitInteraction player_hit;
    Animator animator;
    Rigidbody player_rb;
    AudioSource audioSource;
    bool is_invincible = false;

    // Start is called before the first frame update
    void Start()
    {
        player_control = GetComponent<PlayerMovement>();
        player_health = GetComponent<HasHealth>();
        player_hit = GetComponent<HitInteraction>();

        player_rb = GetComponent<Rigidbody>();

        animator = GetComponent<Animator>();
        audioSource = Camera.main.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        is_invincible = Inventory.god_mode;
    }

    private void OnCollisionEnter(Collision other) {
        GameObject object_collider_with = other.gameObject;
        if (object_collider_with.CompareTag("enemy"))
        {
            if (!is_invincible)
            {
                player_health.lose_health(1f);
                if (player_health.is_dead())
                {
                    StartCoroutine(resetGame());
                    return;
                }
                StartCoroutine(HitInteraction(object_collider_with));
            }
        }
    }

    IEnumerator resetGame()
    {
        player_control.enabled = false;
        player_rb.velocity = Vector3.zero;
        audioSource.Stop();
        AudioSource.PlayClipAtPoint(game_over_sound_clip, Camera.main.transform.position);

        animator.SetFloat("horizontal_input", 0f);
        animator.SetFloat("vertical_input", 0f);
        animator.speed = 1f;
        animator.SetTrigger("die");

        GameObject[] enemies = GameObject.FindGameObjectsWithTag("enemy");
        foreach (GameObject enemy in enemies)
        {
            Destroy(enemy);
        }

        yield return new WaitForSeconds(3.0f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        player_control.enabled = true;
    }

    IEnumerator HitInteraction(GameObject enemy)
    {
        is_invincible = true;
        player_control.enabled = false;

        player_hit.hit_stun(enemy);
        AudioSource.PlayClipAtPoint(enemy_attack_sound_clip, Camera.main.transform.position);

        yield return new WaitForSeconds(0.5f);

        player_control.enabled = true;
        is_invincible = false;
    }
}
