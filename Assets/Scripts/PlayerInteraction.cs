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
    Animator animator;
    Rigidbody player_rb;
    AudioSource audioSource;
    bool is_invincible = false;
    SpriteRenderer player_sprite;
    Color player_origin_color;
    float hit_force = 5f;

    // Start is called before the first frame update
    void Start()
    {
        player_control = GetComponent<PlayerMovement>();
        player_health = GetComponent<HasHealth>();

        player_rb = GetComponent<Rigidbody>();
        player_sprite = GetComponent<SpriteRenderer>();
        player_origin_color = player_sprite.color;

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
            EnemyInteraction enemy = object_collider_with.GetComponent<EnemyInteraction>();

            if (!is_invincible)
            {
                player_health.lose_health(enemy.get_attack());
                if (player_health.is_dead())
                {
                    StartCoroutine(resetGame());
                    return;
                }
                StartCoroutine(getHit(object_collider_with));
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

    IEnumerator getHit(GameObject enemy)
    {
        is_invincible = true;
        player_control.enabled = false;

        player_health.hit_stun(player_rb, enemy, hit_force);
        AudioSource.PlayClipAtPoint(enemy_attack_sound_clip, Camera.main.transform.position);
        StartCoroutine(change_color());

        yield return new WaitForSeconds(0.6f);

        player_control.enabled = true;
        is_invincible = false;
    }

    IEnumerator change_color()
    {
        Color player_origin_color = player_sprite.color;
        player_sprite.color = new Color(1, 0, 0, 1);
        yield return new WaitForSeconds(0.1f);
        player_sprite.color = player_origin_color;
    }
}
